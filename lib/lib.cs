using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


enum plaginsName { Sum, Minus, Mult }
/// <summary>
/// Интерфейс, наследуемый классами типа Plugin
/// </summary>
public interface IPlugin
{
    /// <summary>
    /// Получить название плагина
    /// </summary>
    string PlaginName { get; }
    /// <summary>
    /// Возвращает текущую версию плагина.
    /// </summary>
    string Version { get; }
    /// <summary>
    /// Возвращает изображение плагина
    /// </summary>
    System.Drawing.Image Image { get; }
    /// <summary>
    /// Возвращает описание плагина
    /// </summary>
    string Discription { get; }
    /// <summary>
    /// Метод работы с числами, передаваемых в плагин.
    /// </summary>
    /// <param name="input1"></param>
    /// <param name="input2"></param>
    /// <returns></returns>
    int Run(int input1, int input2);
}

interface IPluginFactory
{
    int PluginCount { get; }
    string[] GetPluginNames { get; }
    IPlugin GetPlugin(string pluginName);
}


/// <summary>
///  Класс реализован посредством шаблона Singleton, для возможности наследования интерфейса IPluginFactory.
///  Доступ осуществляется посредством обращения к полю Instance.
/// </summary>
public class Plugins : IPluginFactory
{
    private static readonly Lazy<Plugins> _plugins = new Lazy<Plugins>(() => new Plugins());
    /// <summary>
    /// Экзампляр класса Plugins.
    /// </summary>
    public static Plugins Instance = _plugins.Value;
    private Plugins()
    {
    }
    /// <summary>
    /// Возвращает количество элементов реализующих IPlagin, класса Plugins
    /// </summary>
    public int PluginCount
    {
        get { return Enum.GetNames(typeof(plaginsName)).Length; }
    }
    /// <summary>
    /// Возвращает массив названий элементов IPlugin класса Plugins
    /// </summary>
    public string[] GetPluginNames
    {
        get { return Enum.GetNames(typeof(plaginsName)); }
    }

    /// <summary>
    /// Возвращает  экземпляр класса, реализующий интерфейс IPlagin,  по имени
    /// </summary>
    /// <param name="pluginName"></param>
    /// <returns></returns>
    public IPlugin GetPlugin(string pluginName)
    {

        IPlugin plugin = null;
        switch (Enum.Parse(typeof(plaginsName), pluginName))
        {
            case plaginsName.Sum:
                {
                    plugin = new Sum();
                    break;
                }
            case plaginsName.Minus:
                {

                    plugin = new Minus();
                    break;
                }
            case plaginsName.Mult:
                {
                    plugin = new Mult();
                    break;
                }
        }
        return plugin;
    }


    abstract class Plugin
    {
        public string _plaginName;
        public string _plaginVersion;
        public System.Drawing.Image _plaginImage;
        public string _plaginDiscription;

        public string PlaginName { get { return _plaginName; } }
        public string Version { get { return _plaginVersion; } }
        public System.Drawing.Image Image { get { return _plaginImage; } }
        public string Discription { get { return _plaginDiscription; } }

    }
    /// <summary>
    /// Сумма элементов
    /// </summary>
     class Sum : Plugin, IPlugin
     {
        public Sum()
        {
            _plaginName = "Sum";
            _plaginVersion = "0.0.1";
            _plaginDiscription = "Сложение двух чисел";
        }
        /// <summary>
        /// Сложение двух чисел типа int.
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <returns></returns>
        public int Run(int input1, int input2)
        {
            return input1 + input2;
        }
    }
    class Minus : Plugin, IPlugin
    {
        public Minus()
        {
            _plaginName = "Minus";
            _plaginVersion = "0.0.1";
            _plaginDiscription = "Вычитание двух чисел";
        }
        /// <summary>
        /// Сложение двух чисел. Из числа <param name="input1"></param> вычитается <param name="input2"></param>.
        /// </summary>
        /// 
        /// 
        /// <returns></returns>
        public int Run(int input1, int input2)
        {
            return input1 - input2;
        }
    }
    class Mult : Plugin, IPlugin
    {
        public Mult()
        {
            _plaginName = "Mult";
            _plaginVersion = "0.0.1";
            _plaginDiscription = "Умножение двух чисел";
        }
        /// <summary>
        /// Сложение двух чисел. Из числа <param name="input1"></param> вычитается <param name="input2"></param>.
        /// </summary>
        /// 
        /// 
        /// <returns></returns>
        public int Run(int input1, int input2)
        {
            return input1 * input2;
        }
    }
}




