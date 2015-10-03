using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveNote.Model;

namespace SaveNote.Global.Auth
{
    public interface IUserProvider
    {
        User User { get; set; }
    }
}
