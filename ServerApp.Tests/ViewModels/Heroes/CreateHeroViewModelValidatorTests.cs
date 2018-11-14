using NUnit.Framework;
using ServerApp.ViewModels.Characters.Heroes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerApp.Tests.ViewModels.Heroes
{
    class CreateHeroViewModelValidatorTests
    {
        public CreateHeroViewModelValidator ViewValidator { get; set; }

        [SetUp]
        public void CreateHeroViewModelValidatorTestsSetUp()
        {
            this.ViewValidator = new CreateHeroViewModelValidator();
        }

        public static IEnumerable<TestCaseData> IsValid_TestCases
        {
            get
            {
                //yield return new TestCaseData(new CreateHeroViewModel() { Name = null                        })
                //.SetDescription("Name is Null").Returns(false);

                // Name length less 4
                yield return new TestCaseData(new SignupHeroViewModel() { Name = ""   }).Returns(false);
                yield return new TestCaseData(new SignupHeroViewModel() { Name = "A"  }).Returns(false);
                yield return new TestCaseData(new SignupHeroViewModel() { Name = "Ab" }).Returns(false);
                yield return new TestCaseData(new SignupHeroViewModel() { Name ="Abc" }).Returns(false);

                // Name length is larger then 20
                yield return new TestCaseData(new SignupHeroViewModel() { Name = "Absdefghijklmnopqrstuvwxyz" }).Returns(false);

                // Name Must be trimmed left.
                yield return new TestCaseData(new SignupHeroViewModel() { Name = " Invalid"  }).Returns(false);
                yield return new TestCaseData(new SignupHeroViewModel() { Name = "Invalid "  }).Returns(false);
                yield return new TestCaseData(new SignupHeroViewModel() { Name = " Invalid " }).Returns(false);

                // Name mustn't contain separator characters except white-spaces.
                yield return new TestCaseData(new SignupHeroViewModel() { Name = "\nInvalid" }).Returns(false);
                yield return new TestCaseData(new SignupHeroViewModel() { Name = "Inva\nlid" }).Returns(false);
                yield return new TestCaseData(new SignupHeroViewModel() { Name = "Invalid\n" }).Returns(false);

                // Name can contain Latin letters only: a-z, A-Z.
                yield return new TestCaseData(new SignupHeroViewModel() { Name = "ыInvalid" }).Returns(false);
                yield return new TestCaseData(new SignupHeroViewModel() { Name = "Invaыlid" }).Returns(false);
                yield return new TestCaseData(new SignupHeroViewModel() { Name = "Invalidы" }).Returns(false);

                // Name mustn't contain Punctuation characters.
                yield return new TestCaseData(new SignupHeroViewModel() { Name = "-Invalid" }).Returns(false);
                yield return new TestCaseData(new SignupHeroViewModel() { Name = "Inva,lid" }).Returns(false);
                yield return new TestCaseData(new SignupHeroViewModel() { Name = "Invalid," }).Returns(false);

                // Name mustn't contain  marks.
                yield return new TestCaseData(new SignupHeroViewModel() { Name = "҈Invalid" }).Returns(false);
                yield return new TestCaseData(new SignupHeroViewModel() { Name = "Inva҈lid" }).Returns(false);
                yield return new TestCaseData(new SignupHeroViewModel() { Name = "Invalid҈" }).Returns(false);

                // Name mustn't contain symbols.
                yield return new TestCaseData(new SignupHeroViewModel() { Name = "+Invalid" }).Returns(false);
                yield return new TestCaseData(new SignupHeroViewModel() { Name = "Inva+lid" }).Returns(false);
                yield return new TestCaseData(new SignupHeroViewModel() { Name = "Invalid+" }).Returns(false);

                yield return new TestCaseData(new SignupHeroViewModel() { Name = "Valid" }).Returns(true);
            }
        }
        
        [Test, TestCaseSource(nameof(IsValid_TestCases))]
        public bool Validate(SignupHeroViewModel viewModel)
        {            
            var result =  this.ViewValidator.Validate(viewModel);

            return result.IsValid;
        }
    }
}
