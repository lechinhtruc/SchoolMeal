using BaoCaoTienAn.Controllers;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolMeal.WebApp.ViewModels;
using System.Collections.Generic;

namespace SchoolMeal.WebApp.Controllers
{

    //[Authorize(Roles = "Admin")]
    public class ManageAccountController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly string RootName = "Quản lí";

        public ManageAccountController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TaoTaiKhoan()
        {
            return View();
        }

        public async Task<IActionResult> TaiKhoan()
        {
            ViewData["Root"] = RootName;
            var accounts = await _unitOfWork.ManageAccounts.GetAllAccount();
            return View(accounts);
        }

        public async Task<IActionResult> LichSuHoatDong()
        {
            ViewData["Root"] = RootName;
            return View(await _unitOfWork.UserLog.GetAll());
        }

        public async Task<IActionResult> XoaLichSuHoatDong()
        {
            await _unitOfWork.UserLog.Clear();
            return RedirectToAction("LichSuHoatDong");
        }

        [HttpGet]
        public async Task<IActionResult> ShowUpdateAccountModal(int Id)
        {
            var account = await _unitOfWork.Account.GetAccountInfomation(Id);
            var roles = await _unitOfWork.ManageAccounts.GetAccountRoles(Id);
            List<RoleModel> roleList = new()
            {
                new RoleModel { DisplayString="Xem danh sách người dùng", ActionName = "TaiKhoan", IsChecked = roles.Any(x => x.ActionName == "TaiKhoan" ) },
                new RoleModel { DisplayString="Tạo người dùng", ActionName = "CreateAccount", IsChecked = roles.Any(x => x.ActionName == "CreateAccount" ) },
                new RoleModel { DisplayString="Sửa người dùng", ActionName = "UpdateAccount", IsChecked = roles.Any(x => x.ActionName == "UpdateAccount" ) },
                new RoleModel { DisplayString="Xoá người dùng", ActionName = "DeleteAccount", IsChecked = roles.Any(x => x.ActionName == "DeleteAccount" ) },
                new RoleModel { DisplayString="Xem lịch sử hoạt động", ActionName = "LichSuHoatDong", IsChecked = roles.Any(x => x.ActionName == "LichSuHoatDong" ) },
                new RoleModel { DisplayString="Xoá lịch sử hoạt động", ActionName = "XoaLichSuHoatDong", IsChecked = roles.Any(x => x.ActionName == "XoaLichSuHoatDong" ) },
                new RoleModel { DisplayString="Báo cáo tiền ăn", ActionName = "TienAn", IsChecked = roles.Any(x => x.ActionName == "TienAn" ) },
            };
            EditUserViewModel editUser = new()
            {
                Id = account.Id,
                Username = account.Username,
                PhoneNumber = account.PhoneNumber,
                ExpiredAt = account.ExpiredAt,
            };
            ViewData["RolesList"] = roleList;
            return PartialView("_EditUserModalPartial", editUser);
        }

        [HttpGet]
        public IActionResult ShowCreateAccountModal()
        {
            return PartialView("_CreateAccountModalPartial");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAccount(EditUserViewModel editUser, List<RoleModel> rolesList)
        {
            if (ModelState.IsValid)
            {
                var account = await _unitOfWork.Account.GetAccountInfomation(editUser.Id);
                account.Username = editUser.Username;
                account.PhoneNumber = editUser.PhoneNumber;
                account.ExpiredAt = editUser.ExpiredAt;
                await _unitOfWork.ManageAccounts.UpdateAccount(account, rolesList);
            }
            return RedirectToAction("TaiKhoan");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAccount(int Id)
        {
            await _unitOfWork.ManageAccounts.DeleteAccount(Id);
            return RedirectToAction("TaiKhoan");
        }

        [HttpPost]
        [ActionName("TaoTaiKhoan")]
        public async Task<IActionResult> CreateAccount(AccountModel account)
        {
            if (ModelState.IsValid)
            {
                var user = await _unitOfWork.ManageAccounts.CreateAccount(account);
                if (user.Id != 0)
                {
                    TempData["Result"] = "Tạo tài khoản thành công!";
                }
            }
            return RedirectToAction("TaiKhoan");
        }
    }
}
