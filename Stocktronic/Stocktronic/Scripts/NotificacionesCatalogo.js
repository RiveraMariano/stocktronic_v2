// This function trigger when you add a product to the cart
function addCart(nombre) {
    Swal.fire({
        // bottom-start, bottom-end, top-start
        position: "top-end",
        icon: "success",
        title: `${nombre} agregado al carrito`,
        showConfirmButton: false,
        timer: 2000,
        toast: true,
    });
}

// This function will trigger when you subtract a product quantity
function minusCart(nombre) { 
    Swal.fire({
        // bottom-start, bottom-end, top-start
        position: "top-end",
        icon: "error",
        title: `Se eliminó un/a ${nombre} del carrito`,
        showConfirmButton: false,
        timer: 2000,
        toast: true,
    });
}

// This function will trigger when you add a product quantity
function plusCart(nombre) {
    Swal.fire({
        // bottom-start, bottom-end, top-start
        position: "top-end",
        icon: "success",
        title: `Se agregó un/a ${nombre} al carrito`,
        showConfirmButton: false,
        timer: 2000,
        toast: true,
    });
}