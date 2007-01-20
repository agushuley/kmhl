using System;
using System.Collections.Generic;
using System.Text;

namespace g {
    public class Class {
		/// <summary>
		/// Создает экземпляр объекта указанного типа.
		/// </summary>
		/// <param name="typeFullName">Название типа в формате {TypeName[, AssemblyName]}. Если не задано имя сборки, то
		/// тип загружается из сборки, которйо принадлежит тип &lt;defaultType&gt; </param>
		/// <param name="defaultType">Тип, для идентификации сборки</param>
		/// <exception cref="System.ArgumentException">Задано неправильное имя типа, невозможно загрузить указанную сборку, нет сборки для типа</exception>
		/// <returns>Экземпляр объекта</returns>
		public static T CreateInstance<T>(string typeFullName, System.Type defaultType) {
			System.Reflection.Assembly assembly = null; // сборка, с которой будет загружатся тип
			string typeName;							// Название типа
			string typeAssemblyName = "";		// Название сборки
			string[] typeNameParts;					// Расчепленная строка имени типа
			T instance = default(T);			// Экземпляр объекта

			// Если нам передан тип, для идантификации сборки, ищем ее
			if (defaultType !=null) {
				assembly = defaultType.Assembly;
			}

			// Расщепляем полное имя типа на части
			typeNameParts = typeFullName.Split(',');
			// Их у нас не может быть более двух
			if (typeNameParts.Length > 2) {
				throw new ArgumentException("Type must have only two parts");
			}

			// Первая часть имени полного типа есть собственно имя типа
			typeName = typeNameParts[0].Trim();
			// А если есть еще одна часть в полном имени типа, то это есть сборка
			if (typeNameParts.Length >= 2) {
				// Загружаем ее
				typeAssemblyName = typeNameParts[1].Trim();
				assembly = System.Reflection.Assembly.Load(typeAssemblyName);

				// Если сборка не загружена, то тип мы точно уже не загрузим
				if (assembly == null) {
					throw new ArgumentException("Не смогли загрузить сборку " + typeAssemblyName);
				}
			}

			// Если нам не задано имя сборки, и не задан тип для идентификации сборки, то это не есть хороше
			if ((typeAssemblyName == "") && (assembly == null)) {
				throw new ArgumentException("Если не указана сборка для типа, то должен быть указан тип для выбора сборки");
			}

			try {
				// Создаем экземпляр типа
				instance = (T)assembly.CreateInstance(typeName);
				// Если нам не задано имя сборки, и не задан тип для идентификации сборки, то это не есть хороше
				if (instance == null) {
					throw new ArgumentException();
				}
			}
			catch (Exception e) {
				throw new ArgumentException("Не могу создать тип " + typeName, e);
			}

			return instance;
        }

        public static T CreateInstance<T>(string p) {
            return CreateInstance<T>(p, null);
        }
    }
}
