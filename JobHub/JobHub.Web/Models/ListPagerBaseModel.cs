namespace JobHub.Web.Models
{
    using System.Collections.Generic;

    public class ListPagerBaseModel<T> : PagerBaseModel
        where T : class
    {
        public string Name { get; set; }

        public List<T> Items { get; set; }
    }
}
