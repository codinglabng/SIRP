//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PRIS.Data.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClientsTable
    {
        public int Id { get; set; }
        public string Enabled { get; set; }
        public string ClientName { get; set; }
        public Nullable<int> ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectUrl { get; set; }
        public string LogoutRedirectUrl { get; set; }
        public string AllowedScopes { get; set; }
    }
}
