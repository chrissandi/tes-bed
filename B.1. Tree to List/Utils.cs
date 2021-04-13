using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SectionB.Classes;

namespace TreeToList
{
    public static class Utils
    {
        public static string GetMap(IEnumerable<ListItem> listItems)
        {
            string map = string.Empty;
            map = string.Join(Environment.NewLine, listItems.Select(x => GetString(x)));
            return map;
        }

        private static string GetString(ListItem listItem)
        {
            return string.Format("Id : {0}, Name : {1}, ParentId : {2}", listItem.Id, listItem.Name, listItem.ParentId);
        }

        public static string CheckAnswer(TreeItem item, string name)
        {
            string result = "Wrong!";
            if (item == null)
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    result = "Yes, Correct!";
                }
            }
            else if (item.Name == name)
            {
                result = "Yes, Correct!";
            }
            return result;
        }
    }
}
