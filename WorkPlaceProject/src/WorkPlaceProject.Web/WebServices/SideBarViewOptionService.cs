namespace WorkPlaceProject.Web.WebServices
{
    public class SideBarViewOptionService
    {
        private bool _navBarVisible = true;

        public Action OnChanged { get; set; }

        //Change state by click on the button
        public void Toggle()
        {
            _navBarVisible = !_navBarVisible;//Change
            if (OnChanged != null) OnChanged();//Callback for reload
        }

        //get additional css class for nav bar div
        public string NavBarClass
        {
            get
            {
                if (_navBarVisible) return String.Empty;//No additional css class for show nav bar
                return "d-none";//d-none class will hide the div
            }
        }
    }
}
