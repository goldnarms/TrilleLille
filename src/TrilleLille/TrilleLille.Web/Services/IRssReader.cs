using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrilleLille.Web.Models;

namespace TrilleLille.Web.Services
{
    public interface IRssReader
    {
        Task<IEnumerable<RssFeed>> ReadFeed();
    }
}
