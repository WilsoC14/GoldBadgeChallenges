using System;
using System.Collections.Generic;
using Komodo_Badge_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Komodo_Badge_Test

{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddBadgeToDictionary()
        {
            //Arrange
            BadgeRepository badgeRepo = new BadgeRepository();
            IDictionary<int, List<string>> badgeAccess = badgeRepo.ReturnDictionary();
            int badgeID = 111;
            string roomAccess = "A101, A102, A103";

            //Act
            badgeRepo.AddBadgeToDictionary(badgeID, roomAccess );

            //Assert
            Assert.AreEqual(1, badgeAccess.Count);
        }

        [TestMethod]
        public void TestAddBadgeAccess()
        {
            //Arrange
            BadgeRepository badgeRepo = new BadgeRepository();
            IDictionary<int, List<string>> badgeAccess = badgeRepo.ReturnDictionary();
            int badgeID = 111;
            string roomAccess = "A101, A102, A103";
            badgeRepo.AddBadgeToDictionary(badgeID, roomAccess);

            //Act
            string roomsToAdd = "B101, B102, B103";
            badgeRepo.AddBadgeAccess(badgeAccess[111], roomsToAdd);

            //Assert
            Assert.AreEqual(6, badgeAccess[111].Count);

        }

        [TestMethod]
        public void TestRemoveBadgeAccess()
        {
            //Arrange
            BadgeRepository badgeRepo = new BadgeRepository();
            IDictionary<int, List<string>> badgeAccess = badgeRepo.ReturnDictionary();
            int badgeID = 111;
            string roomAccess = "A101, A102, A103";
            badgeRepo.AddBadgeToDictionary(badgeID, roomAccess);

            //Act
            badgeRepo.RemoveBadgeAccess(111, "A101, A102");

            //Assert
            Assert.AreEqual(1, badgeAccess[111].Count);
        }

        [TestMethod]
        public void TestRemoveAllRoomsFromBadge()
        {
            //Arrange
            BadgeRepository badgeRepo = new BadgeRepository();
            IDictionary<int, List<string>> badgeAccess = badgeRepo.ReturnDictionary();
            int badgeID = 111;
            string roomAccess = "A101, A102, A103";
            badgeRepo.AddBadgeToDictionary(badgeID, roomAccess);

            //Act
            badgeRepo.RemoveAllRoomsFromBadge(111);

            //Assert
            Assert.AreEqual(0, badgeAccess[111].Count);

        }

        [TestMethod]
        public void TestRemoveBadgeFromDictionary()
        {
            //Arrange
            BadgeRepository badgeRepo = new BadgeRepository();
            IDictionary<int, List<string>> badgeAccess = badgeRepo.ReturnDictionary();
            int badgeID = 111;
            string roomAccess = "A101, A102, A103";
            badgeRepo.AddBadgeToDictionary(badgeID, roomAccess);

            //Act
            badgeRepo.RemoveBadgeFromDictionary(111);
            bool badgeExists = badgeAccess.ContainsKey(111);
            //Assert
            Assert.IsFalse(badgeExists);
        }
    }
}
