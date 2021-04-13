using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SectionC.Classes;

namespace ListToTree
{
    class Program
    {

        /// <summary>
        /// 
        /// Your task here is to implement 2 extension method ToTreeItem and GetMap.
        /// 
        /// ToTreeItem
        /// this method will transform list to tree
        ///   - tree save reference to children in form of object while list save reference to parent Id.
        /// 
        /// GetMap
        /// this method will return string representation of tree item
        /// 
        /// Expected output for GetMap()
        /// Id : 1, Name : Alpha
        /// --Id : 11, Name : Alpha-01
        /// --Id : 12, Name : Alpha-02
        /// ----Id : 121, Name : Alpha-02-Ace
        /// Id : 2, Name : Beta
        /// --Id : 21, Name : Beta-01
        /// ----Id : 211, Name : Beta-01-One
        /// ----Id : 212, Name : Beta-01-Two
        /// ----Id : 213, Name : Beta-01-Three
        /// --Id : 22, Name : Beta-02
        /// ----Id : 221, Name : Beta-02-One
        /// ----Id : 222, Name : Beta-02-Two
        /// ----Id : 223, Name : Beta-02-Three
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
            var listItems = Init.InitListItems();
            var treeItems = CollectionExtensions.ToTreeItem(listItems);

            Console.WriteLine(Environment.NewLine + "=====================================" + Environment.NewLine);
            Console.WriteLine(CollectionExtensions.GetMap(treeItems));
            Console.ReadLine();
        }
    }

    static class CollectionExtensions
    {
        public static List<TreeItem> ToTreeItem(List<ListItem> listItems)
        {
            List<TreeItem> ls = new List<TreeItem>();
            for (int i = 0; i < listItems.Count; i++) {
                ListItem temp = listItems.ElementAt(i);
                if (listItems.ElementAt(i).ParentId == null) {
                    ls.Add(new TreeItem{Id = temp.Id, Name = temp.Name, Children = new List<TreeItem>(){}});
                } else {
                    int j = 0;
                    bool found = false;
                    while (j < ls.Count && found == false) {
                        TreeItem root = ls.ElementAt(j);
                        List<TreeItem> curChilds = root.Children;
                        if (root.Id != temp.ParentId) {
                            while (curChilds.Any() && found == false) {
                                int k = 0;
                                List<TreeItem> curParents = curChilds;
                                curChilds = new List<TreeItem>();
                                while (k < curParents.Count && found == false) {
                                    TreeItem curIdx = curParents.ElementAt(k);
                                    if (curIdx.Id == temp.ParentId) {
                                        curIdx.Children.Add(new TreeItem{Id = temp.Id, Name = temp.Name, Children = new List<TreeItem>()});
                                        found = true;
                                    }
                                    if (curIdx.Children.Any()) {
                                        for (int l = 0; l < curIdx.Children.Count; l++) {
                                            curChilds.Add(curIdx.Children.ElementAt(l));
                                        }
                                    }
                                    k++;
                                }
                            }
                        } else {
                            root.Children.Add(new TreeItem{Id = temp.Id, Name = temp.Name, Children = new List<TreeItem>()});
                        }
                        j++;
                    }
                }
            }
            return ls;
        }

        public static string GetMap(IEnumerable<TreeItem> treeItems)
        {
            string res = string.Empty;
            for(int i = 0;i < treeItems.Count();i++){
                res+= GetDFSTree(treeItems.ElementAt(i),0);
            }
            return res;
        }
        public static string GetDFSTree(TreeItem treeItems, int lvl){
            string tempStrip= string.Empty;
            for (int i = 0; i < lvl * 2; i++) {
                tempStrip += "-";
            }
            string res = tempStrip + "Id : " + treeItems.Id + ", Name : " + treeItems.Name + "\n";
            List<TreeItem> childs = treeItems.Children;
            for(int i=0;i<childs.Count;i++){
                res+= GetDFSTree(childs.ElementAt(i),lvl+1);
            }
            return res;
        }
    }
}
