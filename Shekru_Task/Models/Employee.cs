﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shekru_Task.Models;

public partial class Employee
{
    public int Id { get; set; }

    [Required]
    [RegularExpression(@"^[a-zA-Z\s'-]+$", ErrorMessage = "First name can only contain letters, spaces, hyphens, and apostrophes.")]
    public string Firstname { get; set; }

    [Required]
    [RegularExpression(@"^[a-zA-Z\s'-]+$", ErrorMessage = "Last name can only contain letters, spaces, hyphens, and apostrophes.")]
    public string Lastname { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string EmailAddress { get; set; }
    public int Phonenumber { get; set; }
    public int? DesignationRef { get; set; }

    public int? Graderef { get; set; }

    public virtual Designation DesignationRefNavigation { get; set; }

    public virtual DesignationGrade GraderefNavigation { get; set; }
}