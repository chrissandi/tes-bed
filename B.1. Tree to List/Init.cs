using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SectionB.Classes;

namespace TreeToList
{
    public class Init
    {
        public static List<ListItem> InitListItems()
        {
            return new List<ListItem>
            {
                new ListItem{Id = 1, Name = "Alpha"},
                new ListItem{Id = 11, Name = "Alpha-01", ParentId = 1},
                new ListItem{Id = 12, Name = "Alpha-02", ParentId = 1},
                new ListItem{Id = 121, Name = "Alpha-02-Ace", ParentId = 12},
                new ListItem{Id = 2, Name = "Beta"},
                new ListItem{Id = 21, Name = "Beta-01", ParentId = 2},
                new ListItem{Id = 211, Name = "Beta-01-One", ParentId = 21},
                new ListItem{Id = 212, Name = "Beta-01-Tow", ParentId = 21},
                new ListItem{Id = 213, Name = "Beta-01-Three", ParentId = 21},
                new ListItem{Id = 22, Name = "Beta-02", ParentId = 2},
                new ListItem{Id = 221, Name = "Beta-02-One", ParentId = 22},
                new ListItem{Id = 222, Name = "Beta-02-Two", ParentId = 22},
                new ListItem{Id = 223, Name = "Beta-02-Three", ParentId = 22}
            };
        }

        public static List<TreeItem> InitTreeItems()
        {
            return new List<TreeItem>
            {
                new TreeItem
                {
                    Id = 1, Name = "Alpha", Children = new List<TreeItem>
                    {
                        new TreeItem
                        {
                            Id = 11, Name = "Alpha-01", Children = new List<TreeItem>()
                        },
                        new TreeItem
                        {
                            Id = 12, Name = "Alpha-02", Children = new List<TreeItem>
                            {
                                new TreeItem
                                {
                                    Id = 121, Name = "Alpha-02-Ace", Children = new List<TreeItem>()
                                }
                            }
                        }
                    }
                },
                new TreeItem
                {
                    Id = 2, Name = "Beta", Children = new List<TreeItem>
                    {
                        new TreeItem
                        {
                            Id = 21, Name = "Beta-01", Children = new List<TreeItem>
                            {
                                new TreeItem
                                {
                                    Id = 211, Name = "Beta-01-One", Children = new List<TreeItem>()
                                },
                                new TreeItem
                                {
                                    Id = 212, Name = "Beta-01-Two", Children = new List<TreeItem>()
                                },
                                new TreeItem
                                {
                                    Id = 213, Name = "Beta-01-Three", Children = new List<TreeItem>()
                                }
                            }
                        },
                        new TreeItem
                        {
                            Id = 22, Name = "Beta-02", Children = new List<TreeItem>
                            {
                                new TreeItem
                                {
                                    Id = 221, Name = "Beta-02-One", Children = new List<TreeItem>()
                                },
                                new TreeItem
                                {
                                    Id = 222, Name = "Beta-02-Two", Children = new List<TreeItem>()
                                },
                                new TreeItem
                                {
                                    Id = 223, Name = "Beta-02-Three", Children = new List<TreeItem>()
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
