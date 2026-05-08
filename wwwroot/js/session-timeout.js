window.sessionTimeout = {
    dotnetHelper: null,
    inactivityTimeout: 30 * 60 * 1000, // 30 minutos em milissegundos
    inactivityTimer: null,

    setupActivityListeners: function (dotnetHelper) {
        this.dotnetHelper = dotnetHelper;

        // Eventos de atividade do usuário
        const events = ['mousedown', 'keydown', 'scroll', 'touchstart', 'click'];

        events.forEach(event => {
            document.addEventListener(event, () => this.resetInactivityTimer(), false);
        });

        // Inicia o timer
        this.resetInactivityTimer();
    },

    resetInactivityTimer: function () {
        if (this.inactivityTimer) {
            clearTimeout(this.inactivityTimer);
        }

        this.inactivityTimer = setTimeout(() => {
            this.handleTimeout();
        }, this.inactivityTimeout);
    },

    handleTimeout: function () {
        console.log('Sessão expirada por inatividade');
        // Redireciona para login
        this.redirectToLogin();
    },

    redirectToLogin: function () {
        window.location.href = '/login';
    },

    removeActivityListeners: function () {
        if (this.inactivityTimer) {
            clearTimeout(this.inactivityTimer);
            this.inactivityTimer = null;
        }

        const events = ['mousedown', 'keydown', 'scroll', 'touchstart', 'click'];
        events.forEach(event => {
            document.removeEventListener(event, () => this.resetInactivityTimer());
        });
    }
};
