using ServerApp.Extencions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Characters.Dragons
{
    [NotMapped]
    public class DragonNameGenerator
    {
        private readonly Random random = new Random();


        private DragonName Name   => new DragonName();
        private Random     Random => this.random;

        public string Generate()
        {
            this.Name.ExpectedLength = this.Random.Next(DragonName.MinLength, 6);

            while (this.Name.ActualLength < this.Name.ExpectedLength)
            {
                // Create first letter:
                {
                    if (this.Name.ActualLength == 0)
                    {
                        if (this.Name.ExpectedLength % 2 == 0)
                        {
                            this.Name.Value = this.Name.Value.AppendRandomLatinVowelLetter();
                        }
                        else
                        {
                            this.Name.Value = this.Name.Value.AppendRandomLatinConsonantLetter();
                        }

                        this.Name.Value.ToUpper();
                    }
                }

                // Create letter:
                {
                    if (this.Name.Value.IsLastLetterLatinConsonant())
                    {
                        this.Name.Value = this.Name.Value.AppendRandomLatinVowelLetter();
                    }
                    else
                    {
                        this.Name.Value = this.Name.Value.AppendRandomLatinConsonantLetter();
                    }
                }
            }            

            return this.Name.Value;

        }
    }
}
