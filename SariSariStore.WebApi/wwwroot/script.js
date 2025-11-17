const baseUrl = "https://192.168.254.107:7211/api/Product";
const orderBaseUrl = "https://192.168.254.107:7211/api/Order";
let allCategories = [];

// User management functions
function getUsers() {
    return JSON.parse(localStorage.getItem('users')) || [];
}

function saveUsers(users) {
    localStorage.setItem('users', JSON.stringify(users));
}

function getCurrentUser() {
    return JSON.parse(localStorage.getItem('currentUser'));
}

function setCurrentUser(user) {
    if (user) {
        localStorage.setItem('currentUser', JSON.stringify(user));
    } else {
        localStorage.removeItem('currentUser');
    }
    updateUI();
}

function logoutUser() {
    setCurrentUser(null);
    alert('You have been logged out successfully!');
}

function registerUser(name, email, password) {
    const users = getUsers();

    if (users.find(user => user.email === email)) {
        return { success: false, message: 'User with this email already exists' };
    }

    const newUser = {
        id: Date.now().toString(),
        name,
        email,
        password
    };

    users.push(newUser);
    saveUsers(users);

    return { success: true, user: newUser };
}

function loginUser(email, password) {
    const users = getUsers();
    const user = users.find(user => user.email === email && user.password === password);

    if (user) {
        return { success: true, user };
    } else {
        return { success: false, message: 'Invalid email or password' };
    }
}

// UI update function
function updateUI() {
    const currentUser = getCurrentUser();
    const loginBtn = document.getElementById('login-btn');
    const userMenu = document.getElementById('user-menu');
    const userGreeting = document.getElementById('user-greeting');

    if (currentUser) {
        loginBtn.style.display = 'none';
        userMenu.classList.remove('hidden');
        userGreeting.textContent = `Hello, ${currentUser.name.split(' ')[0]}!`;
    } else {
        loginBtn.style.display = 'block';
        userMenu.classList.add('hidden');
    }
}

// Cart management
function getCart() {
    return JSON.parse(localStorage.getItem('cart')) || [];
}

function saveCart(cart) {
    localStorage.setItem('cart', JSON.stringify(cart));
    updateCartCount();
    if (document.getElementById('cart-modal-body')) {
        updateCartPreview();
    }
}

function addToCart(product) {
    const cart = getCart();
    const productId = product.productID;

    if (!productId) {
        console.error('Product ID is missing:', product);
        alert('Cannot add product to cart: Missing product ID');
        return;
    }

    const existingItem = cart.find(item => item.id === productId);

    if (existingItem) {
        existingItem.quantity += 1;
    } else {
        cart.push({
            id: product.productID,
            name: product.name,
            price: product.discountPrice || product.price,
            image: `${baseUrl}/${productId}/image`,
            quantity: 1,
            category: product.category || 'General',
            stock: product.stock
        });
    }

    saveCart(cart);
    showAddToCartNotification(product.name);
}

function updateCartCount() {
    const cart = getCart();
    const totalItems = cart.reduce((total, item) => total + item.quantity, 0);
    const cartCount = document.getElementById('cart-count');
    if (cartCount) {
        cartCount.textContent = totalItems;

        // Add pulse animation
        cartCount.classList.add('pulse');
        setTimeout(() => cartCount.classList.remove('pulse'), 300);
    }
}

function removeFromCart(productId) {
    const cart = getCart();
    const index = cart.findIndex(item => item.id == productId);

    if (index !== -1) {
        const itemName = cart[index].name;
        cart.splice(index, 1);
        saveCart(cart);
        showRemoveFromCartNotification(itemName);
        return true;
    }
    return false;
}

function updateCartItemQuantity(productId, change) {
    const cart = getCart();
    const item = cart.find(item => item.id == productId);

    if (item) {
        item.quantity += change;

        if (item.quantity <= 0) {
            removeFromCart(productId);
        } else {
            saveCart(cart);
            showQuantityUpdateNotification(item.name, item.quantity);
        }
    }
}

// Notification functions
function showAddToCartNotification(productName) {
    showNotification(`${productName} added to cart!`, 'success');
}

function showRemoveFromCartNotification(productName) {
    showNotification(`${productName} removed from cart`, 'error');
}

function showQuantityUpdateNotification(productName, quantity) {
    showNotification(`${productName} quantity updated to ${quantity}`, 'info');
}

function showNotification(message, type = 'info') {
    const notification = document.createElement('div');
    notification.className = `notification notification-${type}`;
    notification.innerHTML = `
        <i class="fas ${type === 'success' ? 'fa-check-circle' : type === 'error' ? 'fa-exclamation-circle' : 'fa-info-circle'}"></i>
        <span>${message}</span>
    `;

    document.body.appendChild(notification);

    // Animate in
    setTimeout(() => notification.classList.add('show'), 100);

    // Remove after 3 seconds
    setTimeout(() => {
        notification.classList.remove('show');
        setTimeout(() => {
            if (notification.parentNode) {
                notification.parentNode.removeChild(notification);
            }
        }, 300);
    }, 3000);
}

// Cart Modal Functions
function createCartModal() {
    if (document.getElementById('cart-modal')) return;

    const cartModal = document.createElement('div');
    cartModal.id = 'cart-modal';
    cartModal.className = 'modal';
    cartModal.innerHTML = `
        <div class="modal-content cart-modal-content">
            <span class="close">&times;</span>
            <div class="cart-modal-header">
                <h2>Your Cart</h2>
                <span class="cart-total-items" id="cart-modal-count">0 items</span>
            </div>
            <div class="cart-modal-body" id="cart-modal-body">
                <div class="empty-cart" id="empty-cart-message">
                    <i class="fas fa-shopping-cart"></i>
                    <p>Your cart is empty</p>
                    <button class="btn btn-primary" onclick="closeCartModal()">Continue Shopping</button>
                </div>
            </div>
            <div class="cart-modal-footer" id="cart-modal-footer" style="display: none;">
                <div class="cart-summary">
                    <div class="cart-total">
                        <span>Total:</span>
                        <span id="cart-total-price">₱0.00</span>
                    </div>
                    <button class="btn btn-primary btn-checkout" onclick="proceedToCheckout()">
                        <i class="fas fa-shopping-bag"></i>
                        Proceed to Checkout
                    </button>
                    <button class="btn btn-outline" onclick="closeCartModal()">
                        Continue Shopping
                    </button>
                </div>
            </div>
        </div>
    `;
    document.body.appendChild(cartModal);
    setupCartModalEvents();
}

function setupCartModalEvents() {
    const cartModal = document.getElementById('cart-modal');
    const closeBtn = cartModal.querySelector('.close');

    closeBtn.addEventListener('click', closeCartModal);
    cartModal.addEventListener('click', (e) => {
        if (e.target === cartModal) {
            closeCartModal();
        }
    });
}

function showCartModal() {
    const cartModal = document.getElementById('cart-modal');
    if (!cartModal) {
        createCartModal();
    }
    updateCartPreview();
    cartModal.style.display = 'block';
    document.body.style.overflow = 'hidden';
}

function closeCartModal() {
    const cartModal = document.getElementById('cart-modal');
    if (cartModal) {
        cartModal.style.display = 'none';
        document.body.style.overflow = 'auto';
    }
}

function updateCartPreview() {
    const cart = getCart();
    const cartBody = document.getElementById('cart-modal-body');
    const cartFooter = document.getElementById('cart-modal-footer');
    const cartTotalItems = document.getElementById('cart-modal-count');
    const cartTotalPrice = document.getElementById('cart-total-price');

    if (!cartBody) return;

    if (cart.length === 0) {
        cartBody.innerHTML = `
            <div class="empty-cart" id="empty-cart-message">
                <i class="fas fa-shopping-cart"></i>
                <p>Your cart is empty</p>
                <button class="btn btn-primary" onclick="closeCartModal()">Continue Shopping</button>
            </div>
        `;
        if (cartFooter) cartFooter.style.display = 'none';
        if (cartTotalItems) cartTotalItems.textContent = '0 items';
        if (cartTotalPrice) cartTotalPrice.textContent = '₱0.00';
        return;
    }

    // Calculate totals
    const totalItems = cart.reduce((total, item) => total + item.quantity, 0);
    const subtotal = cart.reduce((total, item) => total + (item.price * item.quantity), 0);
    const total = subtotal;

    // Update header
    if (cartTotalItems) cartTotalItems.textContent = `${totalItems} ${totalItems === 1 ? 'item' : 'items'}`;
    if (cartTotalPrice) cartTotalPrice.textContent = `₱${total.toFixed(2)}`;

    // Build cart items HTML
    let cartHTML = '<div class="cart-items">';

    cart.forEach(item => {
        const itemTotal = item.price * item.quantity;
        cartHTML += `
            <div class="cart-item" data-product-id="${item.id}">
                <div class="cart-item-image">
                    <img src="${item.image}" alt="${item.name}" onerror="this.src='https://via.placeholder.com/80x80?text=Product'">
                </div>
                <div class="cart-item-details">
                    <h4 class="cart-item-name">${item.name}</h4>
                    <p class="cart-item-category">${item.category}</p>
                    <p class="cart-item-price">₱${item.price.toFixed(2)}</p>
                </div>
                <div class="cart-item-controls">
                    <div class="quantity-controls">
                        <button class="quantity-btn minus" onclick="updateCartItemQuantity('${item.id}', -1)">
                            <i class="fas fa-minus"></i>
                        </button>
                        <span class="quantity-display">${item.quantity}</span>
                        <button class="quantity-btn plus" onclick="updateCartItemQuantity('${item.id}', 1)">
                            <i class="fas fa-plus"></i>
                        </button>
                    </div>
                    <div class="cart-item-total">
                        ₱${itemTotal.toFixed(2)}
                    </div>
                    <button class="remove-item-btn" onclick="removeFromCart('${item.id}')" title="Remove item">
                        <i class="fas fa-trash"></i>
                    </button>
                </div>
            </div>
        `;
    });

    cartHTML += '</div>';

    // Build summary HTML
    const summaryHTML = `
        <div class="cart-summary-detailed">
            <div class="summary-row total">
                <span>Total (${totalItems} items):</span>
                <span>₱${total.toFixed(2)}</span>
            </div>
        </div>
    `;

    cartBody.innerHTML = cartHTML;

    if (cartFooter) {
        const cartSummary = cartFooter.querySelector('.cart-summary');
        if (cartSummary) {
            cartSummary.innerHTML = summaryHTML + `
                <button class="btn btn-primary btn-checkout" onclick="proceedToCheckout()">
                    <i class="fas fa-shopping-bag"></i>
                    Proceed to Checkout
                </button>
                <button class="btn btn-outline" onclick="closeCartModal()">
                    Continue Shopping
                </button>
            `;
        }
        cartFooter.style.display = 'block';
    }
}

// Checkout and Order Functions
function proceedToCheckout() {
    const cart = getCart();
    const currentUser = getCurrentUser();

    if (cart.length === 0) {
        alert('Your cart is empty! Please add some items before checking out.');
        return;
    }

    if (!currentUser) {
        if (confirm('You need to be logged in to checkout. Would you like to login now?')) {
            closeCartModal();
            showLoginModal();
        }
        return;
    }

    closeCartModal();
    showCheckoutModal();
}

function showCheckoutModal() {
    // Remove existing checkout modal if any
    const existingModal = document.getElementById('checkout-modal');
    if (existingModal) {
        existingModal.remove();
    }

    const checkoutModal = document.createElement('div');
    checkoutModal.id = 'checkout-modal';
    checkoutModal.className = 'modal';

    const cart = getCart();
    const currentUser = getCurrentUser();
    const subtotal = cart.reduce((total, item) => total + (item.price * item.quantity), 0);
    const total = subtotal;

    checkoutModal.innerHTML = `
        <div class="modal-content checkout-modal-content">
            <span class="close">&times;</span>
            <div class="checkout-header">
                <h2>Checkout</h2>
                <p>Complete your purchase</p>
            </div>
            <div class="checkout-body">
                <form id="checkout-form">
                    <div class="checkout-section">
                        <h3>Order Information</h3>
                        <div class="customer-info">
                            <p><strong>Customer:</strong> ${currentUser.name}</p>
                            <p><strong>Email:</strong> ${currentUser.email}</p>
                        </div>
                        <div class="form-group">
                            <label for="order-notes">Notes (Optional)</label>
                            <textarea id="order-notes" rows="3" placeholder="Any special instructions or notes for your order..."></textarea>
                        </div>
                    </div>

                    <div class="checkout-section">
                        <h3>Order Summary</h3>
                        <div class="order-summary-items">
                            ${cart.map(item => `
                                <div class="order-summary-item">
                                    <div class="item-info">
                                        <span class="item-name">${item.name}</span>
                                        <span class="item-quantity">Qty: ${item.quantity}</span>
                                    </div>
                                    <span class="item-total">₱${(item.price * item.quantity).toFixed(2)}</span>
                                </div>
                            `).join('')}
                        </div>
                        <div class="order-totals">
                            <div class="total-row grand-total">
                                <span>Total:</span>
                                <span>₱${total.toFixed(2)}</span>
                            </div>
                        </div>
                    </div>

                    <div class="checkout-section">
                        <div class="form-group terms">
                            <label class="checkbox-label">
                                <input type="checkbox" id="terms-agreement" required>
                                I agree to the <a href="#" class="text-link">Terms and Conditions</a> and 
                                <a href="#" class="text-link">Privacy Policy</a>
                            </label>
                        </div>
                    </div>

                    <div class="checkout-actions">
                        <button type="button" class="btn btn-outline" onclick="closeCheckoutModal()">
                            <i class="fas fa-arrow-left"></i> Back to Cart
                        </button>
                        <button type="submit" class="btn btn-primary" id="place-order-btn">
                            <i class="fas fa-shopping-bag"></i> Place Order - ₱${total.toFixed(2)}
                        </button>
                    </div>
                </form>
            </div>
        </div>
    `;

    document.body.appendChild(checkoutModal);
    setupCheckoutModalEvents();
    checkoutModal.style.display = 'block';
    document.body.style.overflow = 'hidden';
}

function setupCheckoutModalEvents() {
    const checkoutModal = document.getElementById('checkout-modal');
    const closeBtn = checkoutModal.querySelector('.close');
    const form = document.getElementById('checkout-form');

    closeBtn.addEventListener('click', closeCheckoutModal);
    checkoutModal.addEventListener('click', (e) => {
        if (e.target === checkoutModal) {
            closeCheckoutModal();
        }
    });

    form.addEventListener('submit', handleOrderSubmission);
}

function closeCheckoutModal() {
    const checkoutModal = document.getElementById('checkout-modal');
    if (checkoutModal) {
        checkoutModal.style.display = 'none';
        document.body.style.overflow = 'auto';
        setTimeout(() => {
            if (checkoutModal.parentNode) {
                checkoutModal.parentNode.removeChild(checkoutModal);
            }
        }, 300);
    }
}

async function handleOrderSubmission(e) {
    e.preventDefault();

    const placeOrderBtn = document.getElementById('place-order-btn');
    const originalText = placeOrderBtn.innerHTML;
    placeOrderBtn.innerHTML = '<i class="fas fa-spinner fa-spin"></i> Processing Order...';
    placeOrderBtn.disabled = true;

    try {
        const cart = getCart();
        const currentUser = getCurrentUser();

        const orderData = {
            customerName: currentUser.name,
            notes: document.getElementById('order-notes').value || '',
            remarks: 'Order From SariSync Web App',
            isPaid: false,
            items: cart.map(item => ({
                productID: parseInt(item.id),
                quantity: parseInt(item.quantity)
            }))
        };

        console.log('Submitting order:', orderData);

        const response = await fetch(`${orderBaseUrl}/CreateOrder`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(orderData)
        });

        if (!response.ok) {
            const errorText = await response.text();
            throw new Error(`Server error: ${response.status} - ${errorText}`);
        }

        const result = await response.json();
        console.log('Order created successfully:', result);

        // Clear cart and show success
        saveCart([]);
        closeCheckoutModal();
        showOrderSuccess(result);

    } catch (error) {
        console.error('Error creating order:', error);
        alert(`Order failed: ${error.message}`);

        // Reset button
        placeOrderBtn.innerHTML = originalText;
        placeOrderBtn.disabled = false;
    }
}

function showOrderSuccess(orderResult) {
    const successModal = document.createElement('div');
    successModal.id = 'success-modal';
    successModal.className = 'modal';
    successModal.innerHTML = `
        <div class="modal-content success-modal-content">
            <div class="success-icon">
                <i class="fas fa-check-circle"></i>
            </div>
            <div class="success-details">
                <h2>Order Confirmed!</h2>
                <p>Thank you for your purchase. Your order has been received.</p>
                <div class="order-info">
                    <div class="info-item">
                        <strong>Order ID:</strong> ${orderResult.orderId || 'N/A'}
                    </div>
                </div>
            </div>
            <div class="success-actions">
                <button class="btn btn-primary" onclick="closeSuccessModal()">
                    <i class="fas fa-shopping-bag"></i> Continue Shopping
                </button>
            </div>
        </div>
    `;

    document.body.appendChild(successModal);
    successModal.style.display = 'block';

    // Setup close event
    successModal.addEventListener('click', (e) => {
        if (e.target === successModal) {
            closeSuccessModal();
        }
    });
}

function closeSuccessModal() {
    const successModal = document.getElementById('success-modal');
    if (successModal) {
        successModal.style.display = 'none';
        document.body.style.overflow = 'auto';
        setTimeout(() => {
            if (successModal.parentNode) {
                successModal.parentNode.removeChild(successModal);
            }
        }, 300);
    }
}

// Product and Category Management
async function fetchCategories() {
    try {
        const productsResponse = await fetch(baseUrl);
        if (productsResponse.ok) {
            const products = await productsResponse.json();
            allCategories = [...new Set(products.map(product => product.category).filter(Boolean))];
            allCategories.sort();
            displayCategories(allCategories);
        } else {
            throw new Error('Failed to fetch products');
        }
    } catch (error) {
        console.error('Error fetching categories:', error);
        allCategories = ['Snacks', 'Beverages', 'Canned Goods', 'Personal Care', 'Rice & Grains', 'Cooking Oil'];
        displayCategories(allCategories);
    }
}

function displayCategories(categories) {
    const navLinks = document.querySelector('.nav-links');
    const categoryDropdown = document.querySelector('.category-dropdown');

    const allLink = navLinks.querySelector('[data-category="all"]');
    navLinks.innerHTML = '';
    if (allLink) {
        navLinks.appendChild(allLink);
    }

    if (categoryDropdown) {
        categoryDropdown.innerHTML = '<option value="all">All Categories</option>';
    }

    categories.forEach(category => {
        const categoryLink = document.createElement('a');
        categoryLink.href = '#';
        categoryLink.className = 'nav-link';
        categoryLink.setAttribute('data-category', category);
        categoryLink.textContent = truncateCategoryName(category);
        categoryLink.title = category;
        navLinks.appendChild(categoryLink);

        // Dropdown options
        if (categoryDropdown) {
            const option = document.createElement('option');
            option.value = category;
            option.textContent = category;
            categoryDropdown.appendChild(option);
        }
    });

    setupResponsiveCategories();
}

function truncateCategoryName(name, maxLength = 15) {
    return name.length <= maxLength ? name : name.substring(0, maxLength) + '...';
}

function setupResponsiveCategories() {
    const navLinks = document.querySelector('.nav-links');
    const categoryDropdown = document.querySelector('.category-dropdown');

    function checkViewport() {
        if (window.innerWidth <= 768) {
            navLinks.style.display = 'none';
            if (categoryDropdown) {
                categoryDropdown.style.display = 'block';
            }
        } else {
            navLinks.style.display = 'flex';
            if (categoryDropdown) {
                categoryDropdown.style.display = 'none';
            }
        }
    }

    checkViewport();
    window.addEventListener('resize', checkViewport);

    // Dropdown change handler
    if (categoryDropdown) {
        categoryDropdown.addEventListener('change', function (e) {
            const category = e.target.value;
            document.querySelectorAll('.nav-link').forEach(link => {
                link.classList.remove('active');
                if (link.getAttribute('data-category') === category) {
                    link.classList.add('active');
                }
            });
            filterProductsByCategory(category);
        });
    }
}

// Product management
async function fetchProducts() {
    try {
        const response = await fetch(baseUrl);
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        const products = await response.json();
        displayProducts(products);
    } catch (error) {
        console.error('Error fetching products:', error);
        const container = document.getElementById('products-container');
        container.innerHTML = '<p>Failed to load products. Please try again later.</p>';
    }
}

function displayProducts(products) {
    const container = document.getElementById('products-container');
    container.innerHTML = '';

    products.forEach(product => {
        const productCard = document.createElement('div');
        productCard.className = 'product-card';
        productCard.setAttribute('data-product-id', product.productID);

        // Product image
        const productImage = document.createElement('div');
        productImage.className = 'product-image';

        const img = document.createElement('img');
        if (product.productID) {
            img.src = `${baseUrl}/${product.productID}/image`;
        } else {
            img.src = 'https://via.placeholder.com/300x250?text=' + encodeURIComponent(product.name);
        }
        img.alt = product.name;
        img.style.width = '100%';
        img.style.height = '100%';
        img.style.objectFit = 'cover';

        productImage.appendChild(img);
        productCard.appendChild(productImage);

        // Product info
        const productInfo = document.createElement('div');
        productInfo.className = 'product-info';

        const productCategory = document.createElement('div');
        productCategory.className = 'product-category';
        productCategory.textContent = product.category || 'General';
        productInfo.appendChild(productCategory);

        const productName = document.createElement('div');
        productName.className = 'product-name';
        productName.textContent = product.name;
        productInfo.appendChild(productName);

        const productPrice = document.createElement('div');
        productPrice.className = 'product-price';

        const currentPrice = document.createElement('div');
        currentPrice.className = 'current-price';
        currentPrice.textContent = `₱${(product.discountPrice || product.price).toFixed(2)}`;
        productPrice.appendChild(currentPrice);

        if (product.discountPrice && product.discountPrice < product.price) {
            const originalPrice = document.createElement('div');
            originalPrice.className = 'original-price';
            originalPrice.textContent = `₱${product.price.toFixed(2)}`;
            productPrice.appendChild(originalPrice);
        }

        productInfo.appendChild(productPrice);

        const productStock = document.createElement('div');
        productStock.className = 'product-stock';
        productStock.textContent = product.stock > 0 ? `In Stock: ${product.stock}` : 'Out of Stock';
        productInfo.appendChild(productStock);

        const addToCartBtn = document.createElement('button');
        addToCartBtn.className = 'add-to-cart';
        addToCartBtn.textContent = 'Add to Cart';
        addToCartBtn.addEventListener('click', (e) => {
            e.stopPropagation();
            addToCart(product);
        });
        productInfo.appendChild(addToCartBtn);

        productCard.appendChild(productInfo);
        container.appendChild(productCard);

        productCard.addEventListener('click', () => {
            showProductModal(product);
        });
    });
}

function showProductModal(product) {
    const modal = document.getElementById('product-modal');
    const modalContent = document.getElementById('modal-product-details');

    modalContent.innerHTML = `
        <div class="modal-product">
            <div class="modal-product-image">
                <img src="${product.productID ? `${baseUrl}/${product.productID}/image` : `https://via.placeholder.com/300x250?text=${encodeURIComponent(product.name)}`}" 
                     alt="${product.name}" 
                     style="width: 100%; height: 100%; object-fit: cover;">
            </div>
            <div class="modal-product-details">
                <h2>${product.name}</h2>
                <div class="modal-product-category">${product.category || 'General'}</div>
                <div class="modal-product-price">
                <span class="modal-current-price">₱${(product.discountPrice || product.price).toFixed(2)}</span>
                ${product.discountPrice && product.discountPrice < product.price ?
            `<span class="modal-original-price">₱${product.price.toFixed(2)}</span>` : ''}
            </div>
                <div class="modal-product-stock in-stock">${product.stock}</div>
                <button class="modal-add-to-cart" onclick="addToCart(${JSON.stringify(product).replace(/"/g, '&quot;')})">
                    Add to Cart
                </button>
            </div>
        </div>
    `;

    modal.style.display = 'block';
}

// Filtering and search
function setupCategoryFilter() {
    const navLinks = document.querySelector('.nav-links');

    navLinks.addEventListener('click', function (e) {
        if (e.target.classList.contains('nav-link')) {
            e.preventDefault();
            document.querySelectorAll('.nav-link').forEach(l => l.classList.remove('active'));
            e.target.classList.add('active');

            const dropdown = document.querySelector('.category-dropdown');
            if (dropdown) {
                dropdown.value = e.target.getAttribute('data-category');
            }

            const category = e.target.getAttribute('data-category');
            filterProductsByCategory(category);
        }
    });
}

function filterProductsByCategory(category) {
    const productCards = document.querySelectorAll('.product-card');
    const searchTerm = document.getElementById('category-search')?.value.toLowerCase() || '';

    productCards.forEach(card => {
        const productCategory = card.querySelector('.product-category').textContent.toLowerCase();
        const productName = card.querySelector('.product-name').textContent.toLowerCase();

        const matchesCategory = category === 'all' || productCategory.includes(category.toLowerCase());
        const matchesSearch = productName.includes(searchTerm) || productCategory.includes(searchTerm);

        if (matchesCategory && matchesSearch) {
            card.style.display = 'block';
        } else {
            card.style.display = 'none';
        }
    });
}

function setupCategorySearch() {
    const searchBox = document.getElementById('category-search');
    if (searchBox) {
        searchBox.addEventListener('input', function (e) {
            const activeCategory = document.querySelector('.nav-link.active')?.getAttribute('data-category') || 'all';
            filterProductsByCategory(activeCategory);
        });
    }
}

// Modal functionality for login/register
function showLoginModal() {
    const loginModal = document.getElementById('login-modal');
    if (loginModal) {
        loginModal.style.display = 'block';
    }
}

function setupModals() {
    const loginModal = document.getElementById('login-modal');
    const registerModal = document.getElementById('register-modal');
    const productModal = document.getElementById('product-modal');

    const loginBtn = document.getElementById('login-btn');
    const showRegister = document.getElementById('show-register');
    const showLogin = document.getElementById('show-login');
    const closeButtons = document.querySelectorAll('.close');

    loginBtn.addEventListener('click', () => {
        loginModal.style.display = 'block';
    });

    showRegister.addEventListener('click', (e) => {
        e.preventDefault();
        loginModal.style.display = 'none';
        registerModal.style.display = 'block';
    });

    showLogin.addEventListener('click', (e) => {
        e.preventDefault();
        registerModal.style.display = 'none';
        loginModal.style.display = 'block';
    });

    closeButtons.forEach(button => {
        button.addEventListener('click', function () {
            this.closest('.modal').style.display = 'none';
        });
    });

    window.addEventListener('click', (e) => {
        if (e.target.classList.contains('modal')) {
            e.target.style.display = 'none';
        }
    });

    // Login form
    document.getElementById('login-form').addEventListener('submit', function (e) {
        e.preventDefault();
        const email = document.getElementById('username').value;
        const password = document.getElementById('password').value;
        const result = loginUser(email, password);

        if (result.success) {
            setCurrentUser(result.user);
            document.getElementById('login-modal').style.display = 'none';
            alert(`Welcome back, ${result.user.name}!`);
        } else {
            alert(result.message);
        }
    });

    // Register form
    document.getElementById('register-form').addEventListener('submit', function (e) {
        e.preventDefault();
        const name = document.getElementById('reg-username').value;
        const email = document.getElementById('reg-email').value;
        const password = document.getElementById('reg-password').value;
        const confirmPassword = document.getElementById('reg-confirm-password').value;

        if (password !== confirmPassword) {
            alert('Passwords do not match!');
            return;
        }

        const result = registerUser(name, email, password);

        if (result.success) {
            setCurrentUser(result.user);
            document.getElementById('register-modal').style.display = 'none';
            alert(`Welcome to SariSync, ${result.user.name}!`);
        } else {
            alert(result.message);
        }
    });
}

// Cart functionality
function setupCart() {
    const cartIcon = document.querySelector('.cart-icon');
    if (cartIcon) {
        cartIcon.addEventListener('click', showCartModal);
    }
}

// Logout functionality
function setupLogout() {
    document.getElementById('logout-btn').addEventListener('click', function () {
        logoutUser();
    });
}

// Initialize everything
document.addEventListener('DOMContentLoaded', function () {
    updateUI();
    updateCartCount();

    // Load categories first, then products
    fetchCategories().then(() => {
        fetchProducts();
    });

    setupModals();
    setupCategoryFilter();
    setupCategorySearch();
    setupCart();
    setupLogout();

    // Initialize cart modal
    createCartModal();
});