using HM.Data.Entities.GameItems;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HM.Test.GameItems
{
    [TestClass]
    public static class CategoryTest
    {
        [TestMethod]
        [TestCategory("Argument")]
        public static void CategoryArgumentTest(Category category)
        {
            Assert.IsNotNull(category);

            if (string.IsNullOrWhiteSpace(category.Name))
            {
                throw new ArgumentException("Category name has whitespace characters or none: " + category.Name.ToString());
            }
        }

        [TestMethod]
        [TestCategory("Argument")]
        public static void CategoryWordPairingTest(Word word, Category category)
        {
            Assert.AreEqual(word.Category.ID, category.ID);
        }
    }
}
