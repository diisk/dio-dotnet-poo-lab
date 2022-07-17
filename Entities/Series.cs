using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dio_dotnet_poo_lab.Enums;

namespace dio_dotnet_poo_lab.Entities
{
    public class Series : BaseEntity
    {
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }

        private bool removed {get;set;}

        public Series(int id, Genre genre, string title, string description, int year){
            this.ID = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.removed = false;
        }

        public string getTitle(){
            return this.Title;
        }

        public int getID(){
            return this.ID;
        }

        public override string ToString()
        {
            return
            $@"
            Genre: {this.Genre}
            Title: {this.Title}
            Description: {this.Description}
            Year: {this.Year}
            Removed: {this.removed}";
        }

        public void remove(){
            this.removed = true;
        }

        public bool isRemoved(){
            return this.removed;
        }

    }
}