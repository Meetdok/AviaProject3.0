using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WebProject.WebModels;
using WpfProject.Tools;
using WpfProject.WebModels;
using WpfProject.Windows;

namespace WpfProject.ViewModels
{
    public class ListUserVM : BaseTools
    {
        public User SelectedItem { get; set; }
        private List<User> user;
        private List<Post> post;

        public List<User> User
        {
            get => user;
            set
            {
                user = value;

                Signal();
            }
        }

        public List<Post> Post
        {
            get => post;
            set
            {
                post = value;

                Signal();
            }
        }

        public CommandVM DeleteUser { get; set; }


        public ListUserVM()
        {
            Task.Run(async () =>
            {
                var json = await HttpApi.Post("Users", "ListUsers", null);
                User = HttpApi.Deserialize<List<User>>(json);

                var json2 = await HttpApi.Post("Posts", "list", null);
                Post = HttpApi.Deserialize<List<Post>>(json2);

            });

            DeleteUser = new CommandVM(async () =>
            {
                var json = await HttpApi.Post("Users", "delete", SelectedItem.UserId);

                Task.Run(async () =>
                {
                    var json = await HttpApi.Post("Users", "ListUsers", null);
                    User = HttpApi.Deserialize<List<User>>(json);

                    var json2 = await HttpApi.Post("Posts", "list", null);
                    Post = HttpApi.Deserialize<List<Post>>(json2);

                });

            });

        }
    }
}
