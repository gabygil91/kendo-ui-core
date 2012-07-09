﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Mvc.UI.Fluent
{
    /// <summary>
    /// Defines the fluent interface for configuring the <see cref="DataSource"/> component client-side events.
    /// </summary>
    public class DataSourceEventBuilder : EventBuilder
    {
        public DataSourceEventBuilder(IDictionary<string, object> events) : base(events)
        {
        }       
        
        /// <summary>
        /// Defines the name of the JavaScript function that will handle the the Change client-side event.
        /// </summary>  
        /// <param name="handler">JavaScript function name</param>        
        public DataSourceEventBuilder Change(string handler)
        {
            Handler("change", handler);

            return this;
        }

        /// <summary>
        /// Defines the inline handler of the Change client-side event.
        /// </summary>                
        public DataSourceEventBuilder Change(Func<object, object> handler)
        {
            Handler("change", handler);

            return this;
        }

        /// <summary>
        /// Defines the name of the JavaScript function that will handle the the RequestStart client-side event.
        /// </summary> 
        /// <param name="handler">JavaScript function name</param>  
        public DataSourceEventBuilder RequestStart(string handler)
        {
            Handler("requestStart", handler);

            return this;
        }

        /// <summary>
        /// Defines the inline handler of the RequestStart client-side event.
        /// </summary>                
        public DataSourceEventBuilder RequestStart(Func<object, object> handler)
        {
            Handler("requestStart", handler);

            return this;
        }

        /// <summary>
        /// Defines the name of the JavaScript function that will handle the the Error client-side event.
        /// </summary>
        /// <param name="handler">JavaScript function name</param>  
        public DataSourceEventBuilder Error(string handler)
        {
            Handler("error", handler);

            return this;
        }

        /// <summary>
        /// Defines the inline handler of the Error client-side event.
        /// </summary>                
        public DataSourceEventBuilder Error(Func<object, object> handler)
        {
            Handler("error", handler);

            return this;
        }
    }
}