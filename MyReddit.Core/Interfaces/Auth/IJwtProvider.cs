using MyReddit.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReddit.Core.Interfaces.Auth
{
    public interface IJwtProvider
    {
        string Generatetoken(User user);
    }
}
