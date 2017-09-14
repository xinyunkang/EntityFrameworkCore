using System;
using System.Collections.Generic;

namespace ScaffoldFromDatabase
{
    public partial class Samurai
    {
        public Samurai()
        {
            Quote = new HashSet<Quote>();
            SamuraiBattle = new HashSet<SamuraiBattle>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Quote> Quote { get; set; }
        public virtual ICollection<SamuraiBattle> SamuraiBattle { get; set; }
        public virtual SecretIdentity SecretIdentity { get; set; }
    }
}
