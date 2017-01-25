using System;
using System.Web.UI;

namespace UserProfile
{
    public partial class PersonalInfo : Page
    {
        private const string AvatarUrl = "https://s-media-cache-ak0.pinimg.com/564x/ed/ef/a1/edefa19928ce0d67b4c56969142f16a1.jpg";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Avatar.ImageUrl = AvatarUrl;
        }
    }
}