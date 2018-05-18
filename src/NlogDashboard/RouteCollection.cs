﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace NlogDashboard
{
    public class RouteCollection
    {
        private static readonly List<NlogDashboardRoute> Routes = new List<NlogDashboardRoute>();

        public void AddRoute(NlogDashboardRoute route)
        {
            if (route == null)
            {
                throw new ArgumentNullException(nameof(route));
            }

            if (string.IsNullOrWhiteSpace(route.Key))
            {
                throw new ArgumentNullException("route key can bu null");
            }
            if (string.IsNullOrWhiteSpace(route.View))
            {
                throw new ArgumentNullException("route view can bu null");
            }

            if (string.IsNullOrWhiteSpace(route.Action) || string.IsNullOrWhiteSpace(route.Action))
            {
                try
                {
                    var routeArray = route.Key.Split('/');
                    route.Handle = routeArray[0];
                    route.Action = routeArray[1];
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("route key fotmat handle/action", ex);
                }


            }

            if (Routes.Exists(x => x.Key == route.Key))
            {
                Routes[Routes.IndexOf(Routes.FirstOrDefault(x => x.Key == route.Key))] = route;
            }
            else
            {
                Routes.Add(route);
            }

        }

        public NlogDashboardRoute FindRoute(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return Routes.FirstOrDefault(x => x.Key.ToLower() == "Dashboard/Home".ToLower());
            }
  
            return Routes.FirstOrDefault(x => x.Key == url.ToLower());
        }

    }
}