<?php
    include('config.php');
    $username = $_REQUEST['username'];
    
    $sql = "SELECT score_history FROM user WHERE username='$username'";
    $query = $conn->query($sql) or die (mysqli_error($conn));
    while($data = mysqli_fetch_array($query)){
        // echo $data['nama'].";".$data['point_history'].";";
        echo $data['score_history'];
    }
?>