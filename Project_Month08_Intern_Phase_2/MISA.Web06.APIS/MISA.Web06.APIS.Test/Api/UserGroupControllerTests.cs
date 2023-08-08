using Microsoft.AspNetCore.Mvc;
using MISA.Web06.APIS.Api.Controllers;
using MISA.Web06.APIS.Core.Entities;
using MISA.Web06.APIS.Core.Interfaces.Infrastructure;
using MISA.Web06.APIS.Infrastructure.Repository;
using NSubstitute;

namespace MISA.Web06.APIS.Test.Api
{
    public class UserGroupControllerTests
    {
        #region Properties
        private IUserGroupsRepository userGroupsRepositoryFake;
        private UserGroupsController userGroups;
        #endregion

        #region Constructor
        [SetUp]
        public void Setup()
        {
            userGroupsRepositoryFake = Substitute.For<IUserGroupsRepository>();
            userGroups = new UserGroupsController(userGroupsRepositoryFake);
        }
        #endregion

        #region Function
        #region GetByID
        [TestCase(1)]
        public void GetByID_UserGroupIDIsExist_ReturnUserGroupDTO(int UserGroupID)
        {
            // Arrange
            var resFake = new APIS.Core.DTO.UserGroupDTO
            {
                UserGroupID = UserGroupID,
                UserGroupName = "Nhóm abc"
            };
            userGroupsRepositoryFake.GetMemberInGroupByID(UserGroupID).Returns(resFake);

            // Act
            var res = userGroups.GetByID(UserGroupID);

            Assert.AreNotEqual(res, null);
        }

        [TestCase(1)]
        public void GetByID_MySqlConnection_ThrowsException(int UserGroupID)
        {
            // Arrange
            userGroupsRepositoryFake.GetMemberInGroupByID(UserGroupID).Returns(x => { throw new Exception(); });

            // Act
            //var res = userGroups.GetByID(UserGroupID);

            Assert.Throws<Exception>(() => userGroups.GetByID(UserGroupID));
        }

        #endregion

        #region GetAll
        [Test]
        public void GetAll_NoParam_ReturnAllUserGroup()
        {
            // Arrange
            var listUserGroup = new List<UserGroup>() { new UserGroup() };
            userGroupsRepositoryFake.GetAll().Returns(listUserGroup);

            // Act
            var res = userGroups.GetAll();

            // Assert
            //res = res.Result as OkObjectResult;

            Assert.AreNotEqual(res, null);
        }
        #endregion
        #endregion

    }
}