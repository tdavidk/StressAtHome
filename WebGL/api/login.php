<?php 
    include("config.php");

    $username = $_REQUEST['username'];
    $password = md5($_REQUEST['password']);
    $sql = "SELECT * FROM user WHERE username = '$username' AND password = '$password'";

    $query = mysqli_query($conn, $sql) or die (mysqli_error($conn));

    $cek = mysqli_num_rows($query);

    if($cek > 0){
        die("Login Success \n");
    }else{
        die("Login Failed \n");
    }

?>