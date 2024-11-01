using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ProverkaPost_False()
        {
            string N = "Воспитатель";
            bool expected = false;
            Kindergarten.DBConnection.connect_BD();

            bool actual = Kindergarten.Proverkapost.Proverka(N);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProverkaPost_True()
        {
            string name = "ыыы";
            bool expected = true;
            Kindergarten.DBConnection.connect_BD();
            bool actual = Kindergarten.Proverkapost.Proverka("ыыы");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProverkaParentsFalse()
        {
            string kod = "2314572489";
            string telephone_mom = "111";
            string telephone_dad = "222";
            bool expected = false;

            Kindergarten.DBConnection.connect_BD();
            bool actual = Kindergarten.Proverka_parents.Proverka(kod, telephone_mom, telephone_dad);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProverkaParentsTrue()
        {
            string kod = "11";
            string telephone_mom = "111";
            string telephone_dad = "222";
            bool expected = true;

            Kindergarten.DBConnection.connect_BD();
            bool actual = Kindergarten.Proverka_parents.Proverka(kod, telephone_mom, telephone_dad);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProverkaParents2MOM_FALSE()
        {
            string telephone_mom = "5(555)5555555";
            bool expected = false;

            Kindergarten.DBConnection.connect_BD();
            bool actual = Kindergarten.Proverka_parents.Proverka_telephone_mom(telephone_mom);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProverkaParents2MOM_TRUE()
        {
            string telephone_mom = "1(123)2131255";
            bool expected = true;

            Kindergarten.DBConnection.connect_BD();
            bool actual = Kindergarten.Proverka_parents.Proverka_telephone_mom(telephone_mom);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProverkaParents3DAD_FALSE()
        {
            string telephone_dad = "2(222)2222222";
            bool expected = false;

            Kindergarten.DBConnection.connect_BD();
            bool actual = Kindergarten.Proverka_parents.Proverka_telephone_dad(telephone_dad);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProverkaParents3DAD_TRUE()
        {
            string telephone_dad = "1";
            bool expected = true;

            Kindergarten.DBConnection.connect_BD();
            bool actual = Kindergarten.Proverka_parents.Proverka_telephone_dad(telephone_dad);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Proverka_log_staff()
        {
            string log = "admin";
            bool expected = false;

            Kindergarten.DBConnection.connect_BD();
            bool actual = Kindergarten.Proverka_staff_login.Proverka_log(log);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Delete_staff()
        {
            string kod_staff = "1";
            bool expected = false;

            Kindergarten.DBConnection.connect_BD();
            bool actual = Kindergarten.Delete_staff.Delete_Proverka(kod_staff);

            Assert.AreEqual(expected, actual);
        }
    }
}