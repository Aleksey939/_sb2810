были проблемы с .MdiParent=this   не сработало подчеркивает

работает отправка сообщения  на почту (нужен пароль от моей почты)

с помощью вот такого кода нашел свою ошибку почему не сохраняло в БД

try {
                UnitOfWork.Instance.DbContext.SaveChanges();
     }
    catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                    MessageBox.Show("");
                        foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        MessageBox.Show(err.ErrorMessage + "");
                        }
                }
            }