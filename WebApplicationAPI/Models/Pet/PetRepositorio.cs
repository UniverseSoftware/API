﻿using System.Collections.Generic;

namespace WebApplicationAPI.Models.Pet
{
    public class PetRepositorio : IRepositorio<Pet>
    {

        public void Delete(Pet item)
        {
            PetDAL.DeletePet(item.IdPet);
        }

        public IEnumerable<Pet> GetAll()
        {
            return PetDAL.GetPets();
        }

        public Pet GetById(int id)
        {
            return PetDAL.GetPet(id);
        }

        public void Insert(Pet item)
        {
            PetDAL.InsertPet(item);
        }

        public void Update(Pet item)
        {
            PetDAL.UpdatePet(item);
        }

        public IEnumerable<Pet> GetAllPets(int id)
        {
            return PetDAL.GetPetsPessoa(id);
        }

    }
}