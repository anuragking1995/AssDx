//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Deltax
{
    using System;
    using System.Collections.Generic;
    
    public partial class ActorMovie
    {
        public int PKActorMovie { get; set; }
        public string ActorID { get; set; }
        public string MovieID { get; set; }
    
        public virtual Actor Actor { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
