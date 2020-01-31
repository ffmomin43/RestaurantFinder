﻿using System.Collections.Generic;


namespace RestaurantFinder.Repository.Datatables
{
    public class PagedListResult<TEntity>
    {
        //-----------------------------------------------------------------------
        /// <summary>
        /// Does the returned result contains more rows to be retrieved?
        /// </summary>
        public bool HasNext { get; set; }

        //-----------------------------------------------------------------------
        /// <summary>
        /// Does the returned result contains previous items ?
        /// </summary>
        public bool HasPrevious { get; set; }

        //-----------------------------------------------------------------------
        /// <summary>
        /// Total number of rows that could be possibly be retrieved.
        /// </summary>
        public long Count { get; set; }

        //-----------------------------------------------------------------------
        /// <summary>
        /// Result of the query.
        /// </summary>
        public IEnumerable<TEntity> Entities { get; set; }
    }
}