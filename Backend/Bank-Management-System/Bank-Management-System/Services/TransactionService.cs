//using bank_management_system.database;
//using bank_management_system.entities;
//using bank_management_system.constants;
//using bank_management_system.interfaces;
//using system.reflection.metadata.ecma335;

//namespace bank_management_system.services
//{
//    public class transactionservice : itransactionservice
//    {
//        private userinfodbcontext context;

//        public transactionservice()
//        {
//            context = new userinfodbcontext();
//        }

//        private account getaccountfromuserid(int id)
//        {
//            var account = context.accounlist.where(a => a.userinfoid == id).firstordefault();
//            if (account == null)
//            {
//                account = new account { balance = 0, userinfoid = id };
//                context.accounlist.add(account);
//                context.savechanges();
//            }

//            return account;
//        }

//        public bool validatetransaction(transactionrequest t)
//        {
//            var account = getaccountfromuserid(t.userid);

//            if (t.type == constants.constants.withdraw)
//            {
//                if (t.amount > account.balance)
//                {
//                    return false;
//                }
//            }

//            return true;
//        }

//        public transactionresponse withdraw(transactionrequest t)
//        {
//            var account = getaccountfromuserid(t.userid);

//            if (validatetransaction(t))
//            {
//                account.balance -= t.amount ?? 0.0;
//                context.accounlist.update(account);
//                context.savechanges();

//                return new transactionresponse
//                {
//                    accountid = account.id,
//                    userid = account.userinfoid,
//                    status = true,
//                    balance = account.balance
//                };
//            }

//            return new transactionresponse
//            {
//                accountid = account.id,
//                userid = account.userinfoid,
//                status = false,
//                balance = account.balance
//            };
//        }

//        public transactionresponse deposit(transactionrequest t)
//        {
//            var account = getaccountfromuserid(t.userid);

//            if (validatetransaction(t))
//            {
//                account.balance += t.amount ?? 0.0;
//                context.accounlist.update(account);
//                context.savechanges();

//                return new transactionresponse
//                {
//                    accountid = account.id,
//                    userid = account.userinfoid,
//                    status = true,
//                    balance = account.balance
//                };
//            }

//            return new transactionresponse
//            {
//                accountid = account.id,
//                userid = account.userinfoid,
//                status = false,
//                balance = account.balance
//            };
//        }

//        public transactionresponse balance(int id)
//        {
//            var account = getaccountfromuserid(id);

//            return new transactionresponse
//            {
//                accountid = account.id,
//                userid = account.userinfoid,
//                status = true,
//                balance = account.balance
//            };
//        }
//    }
//}
