<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="robots" content="noindex, nofollow">
    <title>Sign In - Bugworx</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@mdi/font@7.4.47/css/materialdesignicons.min.css">
    <link rel="stylesheet" href="${url.resourcesPath}/css/login.css">
</head>
<body>
    <div class="container-fluid p-0" style="min-height: 100vh; overflow: hidden;">
        <div class="row g-0" style="min-height: 100vh;">

            <!-- Left Side - Carousel -->
            <div class="col-lg-7 d-none d-lg-block position-relative carousel-side" id="carouselSide">
                <div class="d-flex flex-column justify-content-center align-items-center h-100 p-5 text-white position-relative" style="z-index: 2;">

                    <!-- Logo -->
                    <div class="position-absolute top-0 start-0 p-4">
                        <h2 class="text-white mb-0">
                            <i class="mdi mdi-bug"></i> Bugworx
                        </h2>
                    </div>

                    <!-- Carousel Content -->
                    <div class="text-center" style="max-width: 600px;">
                        <!-- Slide 1 -->
                        <div class="carousel-slide active" id="slide-0">
                            <h1 class="display-4 fw-bold mb-4">Complete Pest Management Solution</h1>
                            <p class="lead mb-5 opacity-90">Streamline your pest control operations with our all-in-one platform</p>
                            <div class="row g-3 mb-5">
                                <div class="col-6">
                                    <div class="feature-card">
                                        <i class="mdi mdi-check-circle text-white fs-4 mb-2 d-block"></i>
                                        <p class="mb-0 small">Smart Scheduling & Routing</p>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="feature-card">
                                        <i class="mdi mdi-check-circle text-white fs-4 mb-2 d-block"></i>
                                        <p class="mb-0 small">Real-time Tracking</p>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="feature-card">
                                        <i class="mdi mdi-check-circle text-white fs-4 mb-2 d-block"></i>
                                        <p class="mb-0 small">Customer Management</p>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="feature-card">
                                        <i class="mdi mdi-check-circle text-white fs-4 mb-2 d-block"></i>
                                        <p class="mb-0 small">Inventory Control</p>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <!-- Slide 2 -->
                        <div class="carousel-slide" id="slide-1">
                            <h1 class="display-4 fw-bold mb-4">AI-Powered Route Optimization</h1>
                            <p class="lead mb-5 opacity-90">Save time and fuel with intelligent route planning</p>
                            <div class="row g-3 mb-5">
                                <div class="col-6">
                                    <div class="feature-card">
                                        <i class="mdi mdi-check-circle text-white fs-4 mb-2 d-block"></i>
                                        <p class="mb-0 small">3 Optimization Strategies</p>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="feature-card">
                                        <i class="mdi mdi-check-circle text-white fs-4 mb-2 d-block"></i>
                                        <p class="mb-0 small">Real-time Updates</p>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="feature-card">
                                        <i class="mdi mdi-check-circle text-white fs-4 mb-2 d-block"></i>
                                        <p class="mb-0 small">Google Maps Integration</p>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="feature-card">
                                        <i class="mdi mdi-check-circle text-white fs-4 mb-2 d-block"></i>
                                        <p class="mb-0 small">Fuel Cost Tracking</p>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <!-- Carousel Indicators -->
                        <div class="d-flex justify-content-center gap-2">
                            <button class="carousel-dot active" data-slide="0" onclick="goToSlide(0)"></button>
                            <button class="carousel-dot" data-slide="1" onclick="goToSlide(1)"></button>
                        </div>
                    </div>

                    <!-- Bottom Info -->
                    <div class="position-absolute bottom-0 start-0 p-4 w-100">
                        <div class="d-flex justify-content-between align-items-center text-white-50 small">
                            <span>&copy; 2026 Bugworx. All rights reserved.</span>
                            <span>Pest Management System</span>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Right Side - Login Form -->
            <div class="col-lg-5 d-flex align-items-center justify-content-center bg-white">
                <div class="w-100 p-4 p-lg-5" style="max-width: 480px;">

                    <!-- Mobile Logo -->
                    <div class="text-center mb-4 d-lg-none">
                        <h2 class="text-primary mb-0">
                            <i class="mdi mdi-bug"></i> Bugworx
                        </h2>
                        <p class="text-muted small">Pest Management System</p>
                    </div>

                    <div class="mb-4">
                        <h3 class="fw-bold mb-2">Welcome Back!</h3>
                        <p class="text-muted">Please login to your account</p>
                    </div>

                    <!-- Error / Info Messages -->
                    <#if message?has_content && (message.type != 'warning' || !isAppInitiatedAction??)>
                        <div class="alert alert-<#if message.type = 'error'>danger<#else>${message.type}</#if> alert-dismissible fade show" role="alert">
                            <i class="mdi mdi-alert-circle-outline me-2"></i>
                            ${kcSanitize(message.summary)?no_esc}
                            <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
                        </div>
                    </#if>

                    <!-- Login Form -->
                    <form action="${url.loginAction}" method="post">
                        <div class="mb-3">
                            <label for="username" class="form-label fw-semibold">
                                <#if !realm.loginWithEmailAllowed>Username<#elseif !realm.registrationEmailAsUsername>Username or email<#else>Email</#if>
                            </label>
                            <div class="input-group">
                                <span class="input-group-text bg-light border-end-0">
                                    <i class="mdi mdi-account-outline"></i>
                                </span>
                                <input id="username" name="username" type="text"
                                    class="form-control border-start-0 ps-0<#if messagesPerField.existsError('username')> is-invalid</#if>"
                                    value="${(login.username!'')}"
                                    placeholder="Enter your username"
                                    autofocus autocomplete="username">
                            </div>
                            <#if messagesPerField.existsError('username')>
                                <div class="invalid-feedback d-block">${kcSanitize(messagesPerField.get('username'))?no_esc}</div>
                            </#if>
                        </div>

                        <div class="mb-3">
                            <label for="password" class="form-label fw-semibold">Password</label>
                            <div class="input-group">
                                <span class="input-group-text bg-light border-end-0">
                                    <i class="mdi mdi-lock-outline"></i>
                                </span>
                                <input id="password" name="password" type="password"
                                    class="form-control border-start-0 ps-0<#if messagesPerField.existsError('password')> is-invalid</#if>"
                                    placeholder="Enter your password"
                                    autocomplete="current-password">
                            </div>
                            <#if messagesPerField.existsError('password')>
                                <div class="invalid-feedback d-block">${kcSanitize(messagesPerField.get('password'))?no_esc}</div>
                            </#if>
                        </div>

                        <div class="d-flex justify-content-between align-items-center mb-4">
                            <#if realm.rememberMe && !usernameHidden??>
                                <div class="form-check">
                                    <input type="checkbox" class="form-check-input" id="rememberMe" name="rememberMe"
                                        <#if login.rememberMe??>checked</#if>>
                                    <label class="form-check-label" for="rememberMe">Remember me</label>
                                </div>
                            <#else>
                                <div></div>
                            </#if>
                            <#if realm.resetPasswordAllowed>
                                <a href="${url.loginResetCredentialsUrl}" class="text-decoration-none small forgot-password-link">Forgot password?</a>
                            </#if>
                        </div>

                        <button class="btn btn-primary w-100 py-2 mb-3 btn-sign-in" type="submit">
                            <i class="mdi mdi-login me-1"></i> Sign In
                        </button>
                    </form>

                </div>
            </div>
        </div>
    </div>

    <script>
        (function () {
            var currentSlide = 0;
            var totalSlides = 2;
            var gradients = [
                'linear-gradient(135deg, #667eea 0%, #764ba2 100%)',
                'linear-gradient(135deg, #f093fb 0%, #f5576c 100%)'
            ];
            var carouselSide = document.getElementById('carouselSide');

            function showSlide(index) {
                for (var i = 0; i < totalSlides; i++) {
                    var slide = document.getElementById('slide-' + i);
                    var dot = document.querySelectorAll('.carousel-dot')[i];
                    if (i === index) {
                        slide.classList.add('active');
                        dot.classList.add('active');
                    } else {
                        slide.classList.remove('active');
                        dot.classList.remove('active');
                    }
                }
                if (carouselSide) {
                    carouselSide.style.background = gradients[index];
                }
                currentSlide = index;
            }

            window.goToSlide = function (index) {
                showSlide(index);
            };

            // Auto-rotate every 5 seconds
            setInterval(function () {
                showSlide((currentSlide + 1) % totalSlides);
            }, 5000);

            // Initialize
            showSlide(0);
        })();
    </script>
</body>
</html>
