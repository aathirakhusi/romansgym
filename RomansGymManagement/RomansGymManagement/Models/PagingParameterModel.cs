using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RomansGymManagement.Models
{
    public class PagingParameterModel
    {
        const int maxPageSize = 20;  
  
        public int pageNumber { get; set;}
  
        public int _pageSize { get; set; }  
  
        public int pageSize  
        {  
  
            get { return _pageSize; }  
            set  
            {  
                _pageSize = (value > maxPageSize) ? maxPageSize : value;  
            }  
        } 
    }
}