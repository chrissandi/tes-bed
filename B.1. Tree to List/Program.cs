using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SectionB.Classes;

namespace TreeToList
{
    class Program
    {
        /// <summary>
        /// 
        /// Your task here is to implement 2 extension method Get and ToListItem.
        /// 
        /// Get
        /// this method will return object with correct path from root for example : Alpha/Alpha-02/Alpha-02-Ace
        /// if no object with specified path, this method will return null.
        /// string comparison is case insensitive.
        /// 
        /// ToListItem
        /// this method will transform tree to list, the order of list doesn't matter
        ///   - tree save reference to children in form of object while list save reference to parent Id.
        /// 
        /// Expected output for ToListItem
        /// Id : 1, Name : Alpha, ParentId : 
        /// Id : 11, Name : Alpha-01, ParentId : 1
        /// Id : 12, Name : Alpha-02, ParentId : 1
        /// Id : 121, Name : Alpha-02-Ace, ParentId : 12
        /// Id : 2, Name : Beta, ParentId : 
        /// Id : 21, Name : Beta-01, ParentId : 2
        /// Id : 211, Name : Beta-01-One, ParentId : 21
        /// Id : 212, Name : Beta-01-Two, ParentId : 21
        /// Id : 213, Name : Beta-01-Three, ParentId : 21
        /// Id : 22, Name : Beta-02, ParentId : 2
        /// Id : 221, Name : Beta-02-One, ParentId : 22
        /// Id : 222, Name : Beta-02-Two, ParentId : 22
        /// Id : 223, Name : Beta-02-Three, ParentId : 22
        /// 
        /// 
        /// Your scope is limited to this file except class Program and Main method, so you are free to :
        ///   - Change CollectionExtensions class
        ///   - Add new method in CollectionExtensions class
        ///   - Add new class in this file
        /// 
        /// You're NOT allowed to :
        ///   - Change class Program
        ///   - Change Main method
        ///   - Change any file other than this file
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var treeItems = Init.InitTreeItems();

            Console.WriteLine(Utils.CheckAnswer(CollectionExtensions.Get(treeItems, "Alpha/Alpha-02/Alpha-02-Ace"), "Alpha-02-Ace"));
            Console.WriteLine(Utils.CheckAnswer(CollectionExtensions.Get(treeItems, "Alpha1/Alpha-02/Alpha-02-Ace/doesn't_exist"), ""));
            Console.WriteLine(Utils.CheckAnswer(CollectionExtensions.Get(treeItems, "beta/beta-02"), "Beta-02"));
            Console.WriteLine(Utils.CheckAnswer(CollectionExtensions.Get(treeItems, "Beta/Beta-02/beta-02-three"), "Beta-02-Three"));

            Console.WriteLine(Environment.NewLine + "=====================================" + Environment.NewLine);
            Console.WriteLine(Utils.GetMap(CollectionExtensions.ToListItem(treeItems)));
            Console.ReadLine();
        }
    }

    public static class CollectionExtensions
    {
        public static TreeItem Get(List<TreeItem> treeItems, string path)
        {
            string[] temp = path.Split('/');
            for (int i = 0; i < treeItems.Count; i++) {
                if (treeItems.ElementAt(i).Name.Equals(temp[0],StringComparison.InvariantCultureIgnoreCase)) {
                    List<TreeItem> child = treeItems.ElementAt(i).Children;
                    if (temp.Length == 1) {
                        return treeItems.ElementAt(i);
                    } else {
                        string temp1 = path.Substring(temp[0].Length + 1);
                        return Get(child, temp1);
                    }
                }
            }
            return null;
        }

        public static List<ListItem> ToListItem(List<TreeItem> treeItems)
        {
            List<ListItem> ls = new List<ListItem>();
            for (int i = 0; i < treeItems.Count; i++) {
                TreeItem root = treeItems.ElementAt(i);
                List<TreeItem> curChilds = root.Children;
                List<int> parentsId = new List<int>();
                for (int t = 0; t < curChilds.Count; t++) {
                    parentsId.Add(root.Id);
                }
                ls.Add(new ListItem{Id = root.Id, Name = root.Name, ParentId = 0});
                while (curChilds.Any()) {
                    int j = 0;
                    List<TreeItem> curParents = curChilds;
                    curChilds = new List<TreeItem>();
                    List<int> temp = parentsId;
                    parentsId = new List<int>();
                    while (j < curParents.Count) {
                        TreeItem curIdx = curParents.ElementAt(j);
                        ls.Add(new ListItem{Id = curIdx.Id, Name = curIdx.Name, ParentId = temp.ElementAt(j)});
                        if (curIdx.Children.Any()) {
                            for (int k = 0; k < curIdx.Children.Count; k++) {
                                curChilds.Add(curIdx.Children.ElementAt(k));
                                parentsId.Add(curIdx.Id);
                            }
                        }
                        j++;
                    }
                }
            }
            return ls;
        }
    }
}
    
