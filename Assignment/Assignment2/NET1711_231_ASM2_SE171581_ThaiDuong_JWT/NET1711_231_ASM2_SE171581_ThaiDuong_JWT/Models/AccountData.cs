namespace NET1711_231_ASM2_SE171581_ThaiDuong_JWT.Models
{
    public static class AccountData
    {
        public static List<Account> Accounts = new List<Account>()
        {
            new Account(Guid.Parse("130cc9cd-ee18-492c-b8a2-d0c16ef6a738"), "Admin", "123", "admin@gmail.com", "0000000000", "Administrator"),
            new Account(Guid.Parse("f7744da2-1817-4539-b682-d55f33e61a90"), "Manager", "ManagerPass0!", "Manager@gmail.com", "0111111111", "Manager"),
            new Account(Guid.Parse("8b203a18-63a5-40c9-9409-f8ccb3eba382"), "Staff", "StaffPass0!", "Staff@gmail.com", "0222222222", "Staff"),
            new Account(Guid.Parse("2fc530c2-eb0b-4626-81a8-3903726c8f1d"), "User 1", "User1Pass1!", "User1@gmail.com", "0111111111", "Customer"),
            new Account(Guid.Parse("824bdc71-4244-4158-aa08-593afc5ac93d"), "User 2", "User2Pass2!", "User2@gmail.com", "0222222222", "Customer"),
            new Account(Guid.Parse("15b16c6d-a709-45fb-8d4a-00d3dec9a304"), "User 3", "User3Pass3!", "User3@gmail.com", "0333333333", "Customer"),
            new Account(Guid.Parse("93f122ee-d9ce-479c-825d-0a7ed82cea91"), "User 4", "User4Pass4!", "User4@gmail.com", "0444444444", "Customer"),
            new Account(Guid.Parse("276c43cb-d969-4c2f-b027-5971dd18ba09"), "User 5", "User5Pass5!", "User5@gmail.com", "0555555555", "Customer"),
        };
    }
}
