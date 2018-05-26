using System.Collections.Generic;

namespace iTemo.jsGrid
{
    public class GridResponse<T>
    {
        public IEnumerable<T> data { get; set; }
        public int itemsCount { get; set; }

        public GridResponse(IEnumerable<T> data, int itemsCount)
        {
            this.data = data;
            this.itemsCount = itemsCount;
        }
    }
}
