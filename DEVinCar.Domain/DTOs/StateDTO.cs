﻿using DEVinCar.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DEVinCar.Domain.DTOs {
    public class StateDTO {

        //public int Id { get; set; }
        [Required(ErrorMessage ="The Name is required.")]
        [MaxLength(100,ErrorMessage= "State name must be a maximum of 100 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage ="The initiais is required.")]
        [MaxLength(2,ErrorMessage= "State initials must be a maximum of 2 characters.")]
        public string Initials { get; set; }

        public StateDTO()
        {
        }

        public StateDTO(string name, string initials)
        {
           
            Name = name;
            Initials = initials;
        }

        public StateDTO(State state)
        {
            Name = state.Name;
            Initials = state.Initials;

        }

    }
}
