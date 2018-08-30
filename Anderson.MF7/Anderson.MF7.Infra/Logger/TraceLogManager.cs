using log4net;
using System;

namespace Anderson.MF7.Infra.Logger
{
    /// <summary>
    /// Classe responsável por gerenciar log toda nossa aplicação
    /// </summary>
    public static class TraceLogManager
    {
        private static bool _hasBeenConfigurated = false;

        /// <summary>
        /// Flag que indica se o log4net já foi configurado.
        /// </summary>
        public static bool HasBeenConfigurated
        {
            get { return _hasBeenConfigurated; }
        }

        /// <summary>
        /// Retorna o logger (configurado no app.config ou web.config)
        /// </summary>
        public static ILog CurrentClassLogger
        {
            get
            {
                if (!HasBeenConfigurated)
                    Configure();
                return LogManager.GetLogger
                    (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            }
        }

        /// <summary>
        /// Configura o log4net. (de acordo com configurações do app.config ou web.config)
        /// </summary>
        public static void Configure()
        {
            log4net.Config.XmlConfigurator.Configure();
            _hasBeenConfigurated = true;
        }

        #region Debug

        /// <summary>
        /// Loga a mensagem passada. Nível: Debug
        /// </summary>
        /// <param name="messageFunc">Método que irá gerar a mensagem</param>
        public static void Debug(Func<string> messageFunc)
        {
            CurrentClassLogger.Debug(messageFunc);
        }

        /// <summary>
        /// Loga a mensagem passada. Nível: Debug
        /// </summary>
        /// <param name="message">Mensagem</param>
        public static void Debug(string message)
        {
            CurrentClassLogger.Debug(message);
        }

        /// <summary>
        /// Loga a mensagem e exceção passada. Nível: Debug
        /// </summary>
        /// <param name="message">mensagem</param>
        /// <param name="exception">Exceção</param>
        public static void Fatal(string message, Exception exception)
        {
            CurrentClassLogger.Debug(message, exception);
        }

        /// <summary>
        /// Loga a mensagem passada e formata com os parametros passados (string.format). Nível: Debug
        /// </summary>
        /// <param name="message">Mensagem</param>
        /// <param name="args">Pâmetros</param>
        public static void Debug(string message, params object[] args)
        {
            CurrentClassLogger.DebugFormat(message, args);
        }

        #endregion Debug

        #region Error

        /// <summary>
        /// Loga a mensagem passada. Nível: Error
        /// </summary>
        /// <param name="messageFunc">Método que irá gerar a mensagem</param>
        public static void Error(Func<string> messageFunc)
        {
            CurrentClassLogger.Error(messageFunc);
        }

        /// <summary>
        /// Loga a mensagem passada. Nível: Error
        /// </summary>
        /// <param name="message">Mensagem</param>
        public static void Error(string message)
        {
            CurrentClassLogger.Error(message);
        }

        /// <summary>
        /// Loga a mensagem e exceção passada. Nível: Error
        /// </summary>
        /// <param name="message">mensagem</param>
        /// <param name="exception">Exceção</param>
        public static void ErrorException(string message, Exception exception)
        {
            CurrentClassLogger.Error(message, exception);
        }

        /// <summary>
        /// Loga a mensagem passada e formata com os parametros passados (string.format). Nível: Error
        /// </summary>
        /// <param name="message">Mensagem</param>
        /// <param name="args">Pâmetros</param>
        public static void Error(string message, params object[] args)
        {
            CurrentClassLogger.ErrorFormat(message, args);
        }

        #endregion Error

        #region Fatal

        /// <summary>
        /// Loga a mensagem passada. Nível: Fatal
        /// </summary>
        /// <param name="messageFunc">Método que irá gerar a mensagem</param>
        public static void Fatal(Func<string> messageFunc)
        {
            CurrentClassLogger.Fatal(messageFunc);
        }

        /// <summary>
        /// Loga a mensagem passada. Nível: Fatal
        /// </summary>
        /// <param name="message">Mensagem</param>
        public static void Fatal(string message)
        {
            CurrentClassLogger.Fatal(message);
        }

        /// <summary>
        /// Loga a mensagem e exceção passada. Nível: Fatal
        /// </summary>
        /// <param name="message">mensagem</param>
        /// <param name="exception">Exceção</param>
        public static void FatalException(string message, Exception exception)
        {
            CurrentClassLogger.Fatal(message, exception);
        }

        /// <summary>
        /// Loga a mensagem passada e formata com os parametros passados (string.format). Nível: Fatal
        /// </summary>
        /// <param name="message">Mensagem</param>
        /// <param name="args">Pâmetros</param>
        public static void Fatal(string message, params object[] args)
        {
            CurrentClassLogger.FatalFormat(message, args);
        }

        #endregion Fatal

        #region Info

        /// <summary>
        /// Loga a mensagem passada. Nível: Info
        /// </summary>
        /// <param name="messageFunc">Método que irá gerar a mensagem</param>
        public static void Info(string message)
        {
            CurrentClassLogger.Info(message);
        }

        /// <summary>
        /// Loga a mensagem passada. Nível: Info
        /// </summary>
        /// <param name="message">Mensagem</param>
        public static void Info(Func<string> messageFunc)
        {
            CurrentClassLogger.Info(messageFunc);
        }

        /// <summary>
        /// Loga a mensagem e exceção passada. Nível: Info
        /// </summary>
        /// <param name="message">mensagem</param>
        /// <param name="exception">Exceção</param>
        public static void InfoException(string message, Exception exception)
        {
            CurrentClassLogger.Info(message, exception);
        }

        /// <summary>
        /// Loga a mensagem passada e formata com os parametros passados (string.format). Nível: Fatal
        /// </summary>
        /// <param name="message">Mensagem</param>
        /// <param name="args">Pâmetros</param>
        public static void Info(string message, params object[] args)
        {
            CurrentClassLogger.InfoFormat(message, args);
        }

        #endregion Info

        #region Trace

        /// <summary>
        /// Loga a mensagem passada. Nível: Info
        /// </summary>
        /// <param name="message">Mensagem</param>
        public static void Trace(Func<string> messageFunc)
        {
            CurrentClassLogger.Info(messageFunc);
        }

        /// <summary>
        /// Loga a mensagem passada. Nível: Trace
        /// </summary>
        /// <param name="message">Mensagem</param>
        public static void Trace(string message)
        {
            CurrentClassLogger.Info(message);
        }

        /// <summary>
        /// Loga a mensagem e exceção passada. Nível: Trace
        /// </summary>
        /// <param name="message">mensagem</param>
        /// <param name="exception">Exceção</param>
        public static void TraceException(string message, Exception exception)
        {
            CurrentClassLogger.Info(message, exception);
        }

        /// <summary>
        /// Loga a mensagem passada e formata com os parametros passados (string.format). Nível: Trace
        /// </summary>
        /// <param name="message">Mensagem</param>
        /// <param name="args">Pâmetros</param>
        public static void Trace(string message, params object[] args)
        {
            CurrentClassLogger.Info(string.Format(message, args));
        }

        #endregion Trace

        #region Warn

        /// <summary>
        /// Loga a mensagem passada. Nivel: Warn.
        /// </summary>
        /// <param name="messageFunc"></param>
        public static void Warn(Func<string> messageFunc)
        {
            CurrentClassLogger.Warn(messageFunc);
        }

        /// <summary>
        /// Loga a mensagem passada. Nível: Warn
        /// </summary>
        /// <param name="message">Mensagem</param>
        public static void Warn(string message)
        {
            CurrentClassLogger.Warn(message);
        }

        /// <summary>
        /// Loga a mensagem e exceção passada. Nível: Warn
        /// </summary>
        /// <param name="message">mensagem</param>
        /// <param name="exception">Exceção</param>
        public static void WarnException(string message, Exception exception)
        {
            CurrentClassLogger.Warn(message, exception);
        }

        /// <summary>
        /// Loga a mensagem passada e formata com os parametros passados (string.format). Nível: Warn
        /// </summary>
        /// <param name="message">Mensagem</param>
        /// <param name="args">Pâmetros</param>
        public static void Warn(string message, params object[] args)
        {
            CurrentClassLogger.WarnFormat(message, args);
        }

        #endregion Warn
    }
}
