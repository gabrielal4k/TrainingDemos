using System;
using System.Collections.Generic;
using System.Text;

namespace SampleCrud.Contracts.DTO;

internal class DTOPager
{
    public DTOPager(int currentPage, int itemsPerPage)
    {
        this.CurentPage = currentPage;
        this.ItemsPerPage = itemsPerPage;
    }
    public int CurentPage { get; set; }
    public int ItemsPerPage { get; set; }
    public int RecordCount { get; set; }
    //public int PageCount { get; set; }
    //public int ShowingFrom { get; set; }
    //public int ShowingTo { get; set; }

    //not compatible, does not set the new values from request and read them incorrectly due to convertion
    // this are being handled on api side
    public int PageCount
    {
        get
        {
            if (RecordCount == 0) return 0;
            if (ItemsPerPage == 0) return 0;
            return (int)(Math.Ceiling(RecordCount / (double)ItemsPerPage));
        }
    }
    public int ShowingFrom
    {
        get
        {
            if (RecordCount == 0) return 0;
            if (ItemsPerPage == 0) return 0;

            int res = ((CurentPage - 1) * ItemsPerPage) + 1;

            return res;
        }
    }
    public int ShowingTo
    {
        get
        {
            if (RecordCount == 0) return 0;
            if (ItemsPerPage == 0) return 0;
            if (RecordCount < ItemsPerPage) return RecordCount;
            if (CurentPage == PageCount) return RecordCount;
            return ItemsPerPage * CurentPage;
        }
    }
}
