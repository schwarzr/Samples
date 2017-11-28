﻿using System;
using System.Collections.Generic;

namespace AdventureWorksOrder.Model
{
    public partial class ProductModelIllustration
    {
        public int ProductModelId { get; set; }
        public int IllustrationId { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Illustration Illustration { get; set; }
        public ProductModel ProductModel { get; set; }
    }
}
