<?php 
    include("config.php");

    $username = $_REQUEST['username'];
    $password = md5($_REQUEST['password']);
    $score_history = 0;
    $sql = "INSERT INTO user (username, password, score_history) VALUES ('$username', '$password','$score_history')";
    $sql_check_username = "SELECT * FROM user WHERE username='$username'";
    $check_username = mysqli_num_rows(mysqli_query($conn, $sql_check_username));
    echo "username" . $check_username. "<br>";
    if($username == null) {
        die("email null \n");
    }else if($password == null){
        die("password null \n");
    }else  {
        if($check_username > 0){
            die("Username Already Used \n");
        } else {
            mysqli_query($conn, $sql);
            die("Register Succes \n");
        }
    }
    

?>