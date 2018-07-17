﻿using ShukRouting.DataAccess.DataSource;
using ShukRouting.DataAccess.Models;
using ShukRouting.Models;
using ShukRouting.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShukRouting.Mvc.Data
{
    public class CommodityStallRepository
    {
        public List<CommodityStallModel> StallPerItemName(string commodityName)
        {
            using (var context = new ShukRoutingContext())
            {
                List<CommoditiesStalls> Stalls = new List<CommoditiesStalls>();

                Stalls = context.CommoditiesStalls.AsNoTracking()
                    .Where(s => s.Commodity.CommodityName == commodityName)
                    .ToList();

                if (Stalls != null)
                {
                    List<CommodityStallModel> stallsDisplay = new List<CommodityStallModel>();

                    foreach (var stall in Stalls)
                    {
                        var stallDisplay = new CommodityStallModel()
                        {
                            StallName = stall.Stall.StallName,
                            FirstCoord = stall.Stall.FirstCoord,
                            SecondCoord = stall.Stall.SecondCoord
                        };
                        stallsDisplay.Add(stallDisplay);
                    }
                    return stallsDisplay;
                }
                return null;
            }
        }

        public List<CommodityStallModel> LowestPriceForItem(string itemName)
        {
            using (var context = new ShukRoutingContext())
            {
                List<CommoditiesStalls> Stalls = new List<CommoditiesStalls>();

                Stalls = context.CommoditiesStalls.AsNoTracking()
                    .Where(s => s.Commodity.CommodityName == itemName)
                    .OrderBy(s => s.Price)
                    .ToList();

                if (Stalls != null)
                {
                    List<CommodityStallModel> StallsDisplay = new List<CommodityStallModel>();

                    foreach (var stall in Stalls)
                    {
                        var Stalldisplay = new CommodityStallModel()
                        {
                            CommodityName = stall.Commodity.CommodityName,
                            StallName = stall.Stall.StallName,
                            Price = stall.Price,
                            Rating = stall.Rating,
                            TimeRegistered = stall.TimeRegistered,
                            Notes = stall.Notes
                        };
                        StallsDisplay.Add(Stalldisplay);
                    }
                    return StallsDisplay;
                }
                return null;
            }
        }
    }
}