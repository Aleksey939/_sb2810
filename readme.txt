���� �������� � .MdiParent=this   �� ��������� ������������

�������� �������� ���������  �� ����� (����� ������ �� ���� �����)

� ������� ��� ������ ���� ����� ���� ������ ������ �� ��������� � ��

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