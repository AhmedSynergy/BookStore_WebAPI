using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore_WebAPI.CoreFolder.Models
{
    public class PagingParameterModel
    {
        private const int _maxPageSize = 4;
        private int itemsPerPage;

        public int Page  { get; set; } = 1;

        public int ItemsPerPage
        {
            get => itemsPerPage;
            set => itemsPerPage = value > _maxPageSize ? _maxPageSize : value;
            
        }

    }
}