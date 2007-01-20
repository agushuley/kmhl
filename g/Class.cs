using System;
using System.Collections.Generic;
using System.Text;

namespace g {
    public class Class {
		/// <summary>
		/// ������� ��������� ������� ���������� ����.
		/// </summary>
		/// <param name="typeFullName">�������� ���� � ������� {TypeName[, AssemblyName]}. ���� �� ������ ��� ������, ��
		/// ��� ����������� �� ������, ������� ����������� ��� &lt;defaultType&gt; </param>
		/// <param name="defaultType">���, ��� ������������� ������</param>
		/// <exception cref="System.ArgumentException">������ ������������ ��� ����, ���������� ��������� ��������� ������, ��� ������ ��� ����</exception>
		/// <returns>��������� �������</returns>
		public static T CreateInstance<T>(string typeFullName, System.Type defaultType) {
			System.Reflection.Assembly assembly = null; // ������, � ������� ����� ���������� ���
			string typeName;							// �������� ����
			string typeAssemblyName = "";		// �������� ������
			string[] typeNameParts;					// ������������ ������ ����� ����
			T instance = default(T);			// ��������� �������

			// ���� ��� ������� ���, ��� ������������� ������, ���� ��
			if (defaultType !=null) {
				assembly = defaultType.Assembly;
			}

			// ���������� ������ ��� ���� �� �����
			typeNameParts = typeFullName.Split(',');
			// �� � ��� �� ����� ���� ����� ����
			if (typeNameParts.Length > 2) {
				throw new ArgumentException("Type must have only two parts");
			}

			// ������ ����� ����� ������� ���� ���� ���������� ��� ����
			typeName = typeNameParts[0].Trim();
			// � ���� ���� ��� ���� ����� � ������ ����� ����, �� ��� ���� ������
			if (typeNameParts.Length >= 2) {
				// ��������� ��
				typeAssemblyName = typeNameParts[1].Trim();
				assembly = System.Reflection.Assembly.Load(typeAssemblyName);

				// ���� ������ �� ���������, �� ��� �� ����� ��� �� ��������
				if (assembly == null) {
					throw new ArgumentException("�� ������ ��������� ������ " + typeAssemblyName);
				}
			}

			// ���� ��� �� ������ ��� ������, � �� ����� ��� ��� ������������� ������, �� ��� �� ���� ������
			if ((typeAssemblyName == "") && (assembly == null)) {
				throw new ArgumentException("���� �� ������� ������ ��� ����, �� ������ ���� ������ ��� ��� ������ ������");
			}

			try {
				// ������� ��������� ����
				instance = (T)assembly.CreateInstance(typeName);
				// ���� ��� �� ������ ��� ������, � �� ����� ��� ��� ������������� ������, �� ��� �� ���� ������
				if (instance == null) {
					throw new ArgumentException();
				}
			}
			catch (Exception e) {
				throw new ArgumentException("�� ���� ������� ��� " + typeName, e);
			}

			return instance;
        }

        public static T CreateInstance<T>(string p) {
            return CreateInstance<T>(p, null);
        }
    }
}
