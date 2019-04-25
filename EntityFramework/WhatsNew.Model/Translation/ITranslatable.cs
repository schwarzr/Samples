using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsNew.Model.Translation
{
    public interface ITranslatable
    {
        TranslationStore Translation { get; }
    }
}