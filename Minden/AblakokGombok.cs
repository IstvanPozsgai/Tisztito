using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Tisztito.Minden
{
    public static class AblakokGombok
    {
        public static List<Type> FormokListázása()
        {
            List<Type> formTypes = Assembly.GetExecutingAssembly()
                   .GetTypes()
                   .Where(t => t.IsSubclassOf(typeof(Form))).ToList();
            return formTypes;
        }
        public static void MentsdFormokNevetAccessbe()
        {
            List<Type> formTypes = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(t => t.IsSubclassOf(typeof(Form))).ToList();
            string hely = "", jelszó = "";
            string kapcsolat = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='{hely}'; Jet Oledb:Database Password={jelszó}";
            using (var conn = new OleDbConnection(kapcsolat))
            {
                conn.Open();
                foreach (var formType in formTypes)
                {
                    string nev = formType.Name;
                    string sql = $"INSERT INTO Formok (FormNev) VALUES ('{nev}')";
                    using (var cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public static void MentsdFormGombokatAccessbe(Form form, string hely, string jelszo)
        {
            // Gombok lekérdezése rekurzívan
            List<Button> gombok = GetAllButtons(form);

            string kapcsolat = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='{hely}'; Jet Oledb:Database Password={jelszo}";
            using (var conn = new OleDbConnection(kapcsolat))
            {
                conn.Open();
                foreach (var gomb in gombok)
                {
                    string sql = $"INSERT INTO FormGombok (FormNev, GombNev) VALUES ('{form.Name}', '{gomb.Name}')";
                    using (var cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // Segédfüggvény: összes Button lekérdezése rekurzívan
        private static List<Button> GetAllButtons(Control parent)
        {
            List<Button> buttons = new List<Button>();
            foreach (Control c in parent.Controls)
            {
                if (c is Button btn)
                    buttons.Add(btn);
                if (c.HasChildren)
                    buttons.AddRange(GetAllButtons(c));
            }
            return buttons;
        }

        public static void AllitsdBeGombokLathatosagat(Form form, string hely, string jelszo)
        {
            string kapcsolat = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='{hely}'; Jet Oledb:Database Password={jelszo}";
            using (var conn = new OleDbConnection(kapcsolat))
            {
                conn.Open();
                string sql = $"SELECT GombNev, Lathato FROM FormGombok WHERE FormNev = '{form.Name}'";
                using (var cmd = new OleDbCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string gombNev = reader["GombNev"].ToString();
                        bool lathato = Convert.ToBoolean(reader["Lathato"]);
                        var gomb = FindButtonByName(form, gombNev);
                        if (gomb != null)
                            gomb.Visible = lathato;
                    }
                }
            }
        }

        // Segédfüggvény: gomb keresése név alapján, rekurzívan
        private static Button FindButtonByName(Control parent, string name)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Button btn && btn.Name == name)
                    return btn;
                if (c.HasChildren)
                {
                    var found = FindButtonByName(c, name);
                    if (found != null)
                        return found;
                }
            }
            return null;
        }

        /// <summary>
        /// Menü lista készítése a menüsávból
        /// </summary>
        /// <param name="menuStrip"></param>
        /// <returns></returns>
        public static List<ToolStripMenuItem> MenüListaKészítés(MenuStrip menuStrip)
        {
            List<ToolStripMenuItem> items = new List<ToolStripMenuItem>();
            foreach (ToolStripMenuItem item in menuStrip.Items)
            {
                items.Add(item);
                items.AddRange(GetMenuItemsRecursive(item));
            }
            return items;
        }

        private static List<ToolStripMenuItem> GetMenuItemsRecursive(ToolStripMenuItem parent)
        {
            var items = new List<ToolStripMenuItem>();
            foreach (ToolStripItem subItem in parent.DropDownItems)
            {
                if (subItem is ToolStripMenuItem menuItem)
                {
                    items.Add(menuItem);
                    items.AddRange(GetMenuItemsRecursive(menuItem));
                }
            }
            return items;
        }
    }
}
