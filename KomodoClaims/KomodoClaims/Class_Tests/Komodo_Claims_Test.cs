using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Komodo_Claims_Classes;
using System.Collections.Generic;

namespace Komodo_Claims_Test

{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddClaimToQueue()
        {

            //Arrange
            DateTime claimOneIncidentDate = new DateTime(2018, 4, 25);
            DateTime claimOneClaimDate = new DateTime(2018, 4, 27);
            Claim testClaim = new Claim("1", ClaimType.Car, "Car accident on 465.", 400.00, claimOneIncidentDate, claimOneClaimDate);

            Claim_Repository _claimRepo = new Claim_Repository();
            Queue<Claim> queuedClaims = _claimRepo.ReturnQueuedClaims();

            //Act
            _claimRepo.AddClaimToQueue(testClaim);

            Assert.AreEqual(1, queuedClaims.Count);


        }

        [TestMethod]
        public void TestProcessClaim()
        {
            //Arrange
            DateTime claimOneIncidentDate = new DateTime(2018, 4, 25);
            DateTime claimOneClaimDate = new DateTime(2018, 4, 27);
            Claim testClaim = new Claim("1", ClaimType.Car, "Car accident on 465.", 400.00, claimOneIncidentDate, claimOneClaimDate);
            Claim_Repository _claimRepo = new Claim_Repository();
            Queue<Claim> queuedClaims = _claimRepo.ReturnQueuedClaims();

            _claimRepo.AddClaimToQueue(testClaim);

            //Act

            _claimRepo.ProcessClaim();


            //Assert
            Assert.AreEqual(0, queuedClaims.Count);
        }

        [TestMethod]
        public void TestClaimValidity()
        {
            //Arrange
            DateTime claimOneIncidentDate = new DateTime(2018, 4, 25);
            DateTime claimOneClaimDate = new DateTime(2018, 4, 27);
            Claim testClaim = new Claim("1", ClaimType.Car, "Car accident on 465.", 400.00, claimOneIncidentDate, claimOneClaimDate);
            Claim_Repository _claimRepo = new Claim_Repository();
            // Queue<Claim> queuedClaims = _claimRepo.ReturnQueuedClaims();

            //Act
           _claimRepo.ClaimValidity(testClaim, claimOneIncidentDate, claimOneClaimDate);

            Assert.AreEqual(true, testClaim.IsValid);

        }








    }
}
