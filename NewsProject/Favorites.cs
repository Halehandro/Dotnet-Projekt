//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewsProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class Favorites
    {
        public int Id { get; set; }
        public Nullable<int> NewsPieceId { get; set; }

        public override string ToString()
        {
            return News.ToString();
        }

        public virtual News News { get; set; }
    }
}
