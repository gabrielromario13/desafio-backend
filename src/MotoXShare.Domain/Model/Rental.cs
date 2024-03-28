﻿using MotoXShare.Domain.Base;
using MotoXShare.Domain.Enums;

namespace MotoXShare.Domain.Model;

public class Rental(Guid id) : BaseEntity(id)
{
    //Won't be possible to complete the rent if there's no motorcycles available!
    //Only delivery drivers qualified in category A can make a rental!
    public RentalPlans Plan { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Now.AddDays(1); //TODO: Check if this is the best way to do it!
    public DateTime EndDatePrevision { get; set; }
    public DateTime? EndDate { get; set; }
    public bool Active { get; set; } //TODO: Check if this property is really needed!
}
