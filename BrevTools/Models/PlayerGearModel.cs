using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BrevTools.Models
{
    public class PlayerGearModel {}

    public class PlayerGear : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly string missingItemImageURL = "https://i1.wp.com/clipart-library.com/new_gallery/580731_red-circle-with-line-through-it-png.png";
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private string name;
        private string head;
        private string chest;
        private string shoes;
        private string mainhand;
        private string offhand;
        private string cape;
        private string bag;
        private string mount;
        private string reason;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if(name != value)
                {
                    name = value;
                    RaisePropertyChanged("name");
                }
            }
        }

        public string Head
        {
            get
            {
                if (head.Contains("None"))
                {
                    return missingItemImageURL;
                } 
                else
                {
                    return head;
                }
            }
            set
            {
                if (head != value)
                {
                    head = value;
                    RaisePropertyChanged("head");
                }
            }
        }

        public string Chest
        {
            get
            {
                if(chest.Contains("None"))
                {
                    return missingItemImageURL;
                }
                else
                {
                    return chest;
                }
            }
            set
            {
                if (chest != value)
                {
                    chest = value;
                    RaisePropertyChanged("chest");
                }
            }
        }

        public string Shoes
        {
            get
            {
                if (shoes.Contains("None"))
                {
                    return missingItemImageURL;
                }
                else
                {
                    return shoes;
                }
            }
            set
            {
                if (shoes != value)
                {
                    shoes = value;
                    RaisePropertyChanged("shoes");
                }
            }
        }

        public string Mainhand
        {
            get
            {
                if (mainhand.Contains("None"))
                {
                    return missingItemImageURL;
                }
                else
                {
                    return mainhand;
                }
            }
            set
            {
                if (mainhand != value)
                {
                    mainhand = value;
                    RaisePropertyChanged("mainhand");
                }
            }
        }

        public string Offhand
        {
            get
            {
                if (offhand.Contains("None"))
                {
                    return missingItemImageURL;
                }
                else
                {
                    return offhand;
                }
            }
            set
            {
                if (offhand != value)
                {
                    offhand = value;
                    RaisePropertyChanged("offhand");
                }
            }
        }

        public string Cape
        {
            get
            {
                if (cape.Contains("None"))
                {
                    return missingItemImageURL;
                }
                else
                {
                    return cape;
                }
            }
            set
            {
                if (cape != value)
                {
                    cape = value;
                    RaisePropertyChanged("cape");
                }
            }
        }

        public string Bag
        {
            get
            {
                if (bag.Contains("None"))
                {
                    return missingItemImageURL;
                }
                else
                {
                    return bag;
                }
            }
            set
            {
                if (bag != value)
                {
                    bag = value;
                    RaisePropertyChanged("bag");
                }
            }
        }

        public string Mount
        {
            get
            {
                if (mount.Contains("None"))
                {
                    return missingItemImageURL;
                }
                else
                {
                    return mount;
                }
            }
            set
            {
                if (mount != value)
                {
                    mount = value;
                    RaisePropertyChanged("mount");
                }
            }
        }

        public string Reason
        {
            get
            {
                return reason;
            }
            set
            {
                if(reason != value)
                {
                    reason = value;
                    RaisePropertyChanged("reason");
                }
            }
        }
    }
}
